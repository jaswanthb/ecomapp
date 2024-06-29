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
            return customer;
        }

        public Customers UpdateCustomer(Customers customer)
        {
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();

            return customer;
        }

        public bool DeleteCustomer(string customercode)
        {
            try
            {
                var cust = _dbContext.Customers.FirstOrDefault(c => c.CustomerCode == customercode);
                _dbContext.Customers.Update(cust);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public List<Customers> GetCustomers(string searchParam)
        {
            var custList = from c in _dbContext.Customers
                     where c.CustomerCode.Contains(searchParam) select c;

            return _dbContext.Customers.Where(c => c.CustomerCode.Contains(searchParam)).ToList();
        }
    }
}
