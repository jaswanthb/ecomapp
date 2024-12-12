namespace CancellationTknDemo
{
    public interface ITknService
    {
        Task<string> GetDataFromExpensiveOperation(CancellationToken tkn);

        Task<TknModel> GetDatFromDB();
    }
}
