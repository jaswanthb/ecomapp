using eCommerce.Models;
using eCommerce.Models.ViewModels;
using eCommerce.Service.Contracts;
using eCommerceRepository;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eCommerce.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly eCommerceContext _dbContext;
        private readonly ILogger<CustomerService> _logger; // Default logging to console
        private IMemoryCache _memoryCache;
        public CustomerService(eCommerceContext dbContext, ILogger<CustomerService> logger, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public CustomerService(eCommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CustomerService()
        {
            
        }

        public ResponseMessage CreateCustomer(Customers customer)
        {
            ResponseMessage createCustResponseMes = new ResponseMessage();
            try
            {
                var res = _dbContext.Customers.Any(c => c.CustomerCode == customer.CustomerCode);
                if (!res)
                {
                    _dbContext.Customers.Add(customer);
                    _dbContext.SaveChanges();
                    createCustResponseMes.IsError = false;
                    return createCustResponseMes;
                }
                else
                {
                    createCustResponseMes.IsError = true;
                    createCustResponseMes.ErrorMessage = $"Customer already exists with given customer code {customer.CustomerCode}";
                    return createCustResponseMes;
                }
            }
            catch (Exception ex)
            {
                createCustResponseMes.IsError = true;
                createCustResponseMes.ErrorMessage = $"Something went wrong creating customer{customer.CompanyName}";
                return createCustResponseMes;
            }
        }

        public Customers GetCustomerById(int id)
        {
            Customers cust = _dbContext.Customers.First(c => c.CustomerID == id);
            return cust ?? new Customers();
        }

        public ResponseMessage UpdateCustomer(Customers customer)
        {
            ResponseMessage custUpdateresponse = new ResponseMessage();
            //Customers res = null;
            try
            {

                var res = _dbContext.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
                if (res != null)
                {
                    res.CompanyName = customer.CompanyName;
                    res.ContactName = customer.ContactName;
                    res.ContactTitle = customer.ContactTitle;
                    res.Address = customer.Address;
                    res.City = customer.City;
                    res.Region = customer.Region;
                    res.Phone = customer.Phone;
                    res.PostalCode = customer.PostalCode;
                    res.Country = customer.Country;
                    res.Fax = customer.Fax;
                    res.IsActive = customer.IsActive;

                    _dbContext.Customers.Update(res);
                    _dbContext.SaveChanges();
                    custUpdateresponse.IsError = false;
                    return custUpdateresponse;
                }
                else
                {
                    custUpdateresponse.IsError = true;
                    custUpdateresponse.ErrorMessage = $"Customer With {res.CustomerID} Does not Exist";
                    return custUpdateresponse;
                }
            }
            catch (Exception ex)
            {
                custUpdateresponse.IsError = true;
                custUpdateresponse.ErrorMessage = $"Something went wrong when updating the Customer {customer.CustomerID}";
                return custUpdateresponse;
            }
        }
        public ResponseMessage DeleteCustomer(string customercode)
        {
            ResponseMessage customerResponseMessage = new ResponseMessage();
            try
            {
                var cust = _dbContext.Customers.FirstOrDefault(c => c.CustomerCode == customercode);
                if (cust != null)
                {
                    cust.IsActive = false;
                    _dbContext.Customers.Update(cust);
                    _dbContext.SaveChanges();
                    customerResponseMessage.IsError = false;
                    return customerResponseMessage;
                }
                else
                {
                    customerResponseMessage.IsError = true;
                    customerResponseMessage.ErrorMessage = $"Customer With {customercode} Does not Exist";
                    return customerResponseMessage;
                }
            }
            catch (Exception ex)
            {

                customerResponseMessage.IsError = true;
                customerResponseMessage.ErrorMessage = $"Something went wrong when deleting the Customer {customercode}";
                return customerResponseMessage;
            }
        }

        public List<Customers> GetCustomers(string searchParam)
        {
            try
            {
                _logger.LogInformation("Get Customers called.");
                var data = _memoryCache.Get<List<Customers>>("customers");
                if(data is null || data.Count == 0)
                {
                    var custList = from c in _dbContext.Customers
                                   where c.CustomerCode.Contains(searchParam)
                                   select c;

                    _logger.LogInformation("Get Customers got data.");

                    data = _dbContext.Customers.Where(c => c.CustomerCode.Contains(searchParam)).ToList();
                    _memoryCache.Set("customers", data);
                }
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError("Message:"+ex.Message, ex);
                return null;
            }
        }
    }
}
