using eCommerce.Models;
using eCommerce.Service;
using eCommerce.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<Customers> GetCustomers(string searchParam)
        {
            var cust = _customerService.GetCustomers(searchParam);
            return cust;
        }

        [HttpPost]
        [Route("customers")]
        public Customers CreateCustomer(Customers customer)
        {
            var res = _customerService.CreateCustomer(customer);
            return res;
        }
    }
}


/*
 Get
 
 */