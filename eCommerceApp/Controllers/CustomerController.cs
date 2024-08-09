using eCommerce.Models;
using eCommerce.Models.ViewModels;
using eCommerce.Service;
using eCommerce.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        public ResponseMessage CreateCustomer(Customers customer)
        {
            if (customer.CustomerCode.Length >20 || string.IsNullOrEmpty(customer.CustomerCode))
                return new ResponseMessage() {IsError = true,ErrorMessage = "Customer code is empty or customercode length is greater than 20"};

            var res = _customerService.CreateCustomer(customer);
            return res;
        }

        [HttpPut("customers")]
        public ResponseMessage UpdateCustomer(Customers customer)
        {
            var result = _customerService.UpdateCustomer(customer);
            return result;
        }

        [HttpDelete("customers")]
        public ResponseMessage DeleteCustomer(string customerCode)
        {
            var result = _customerService.DeleteCustomer(customerCode);
            return result;
        }
    }
}