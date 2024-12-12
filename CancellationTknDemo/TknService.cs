using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Text;
namespace CancellationTknDemo
{
    public class TknService(TestDBContext _db) : ITknService
    {
        public async Task<string> GetDataFromExpensiveOperation(CancellationToken tkn)
        {
            var str = new StringBuilder();

            for (int i = 0; i < 20; i++)
            {
                str.AppendLine(await GetData(i, tkn));
            }
            return str.ToString();
        }

        private async Task<string> GetData(int i, CancellationToken tkn)
        {
            await Task.Delay(2000, tkn);
            string val = $"Query {i} completed"; // Verbatium literals

            string val1 = "Test" + i + "completed";
            //logger.LogInformation(val);
            Console.WriteLine(val);
            return val;
        }


        //Code first approach
        /*
         1.Create a code template with entityframework
         2. install below packages from manage nuget / run below commands in package manager console
            install-package Microsoft.EntityFrameworkCore -version 8.0.0
            install-package Microsoft.EntityFrameworkCore.design -version 8.0.0
            install-package Microsoft.EntityFrameworkCore.Tools -version 8.0.0
            install-package Microsoft.EntityFrameworkCore.sqlserver -version 8.0.0
        3.Configure dbcontext (check for TestDBContext.cs)
        4.run command in package manager console "add-migration <name>" will create migrations
        5.command "update-database" will update schema and test if specified in database
         */
        public async Task<TknModel> GetDatFromDB()
        {
            return await _db.TknModels.FirstAsync();
        }
    }
}
