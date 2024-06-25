using eCommerce.Models;
using eCommerce.Service.Contracts;
using eCommerceRepository;

namespace eCommerce.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly eCommerceContext _dbContext;
        public CustomerService(eCommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customers CreateCustomer(Customers customer)
        {
            _dbContext.Customers.Add(customer);

            var res = _dbContext.SaveChanges();

            //var newCustomer = _dbContext.Customers.FirstOrDefault(c => c.CustomerID == res);
            return customer;
        }

        public List<Customers> GetCustomers(string searchParam)
        {
            var custList = from c in _dbContext.Customers
                     where c.CustomerCode.Contains(searchParam) select c;

            return _dbContext.Customers.Where(c => c.CustomerCode.Contains(searchParam)).ToList();
        }
    }
}
