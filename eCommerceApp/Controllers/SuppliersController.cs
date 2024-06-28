using eCommerce.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using eCommerce.Models;

namespace eCommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly ICustomerService _customerService;
        public SuppliersController(ISupplierService supplierService, ICustomerService customerService)
        {
            _supplierService = supplierService;
            _customerService = customerService;
        }

        [HttpGet]
        [Route("suppliers")]
        public List<Suppliers> GetSuppliers(string searchQuery)
        {
            return _supplierService.GetSuppliers(searchQuery);
        }

        [HttpGet("Suppliers")]
        public Suppliers InsertSupplier(Suppliers supplier)
        {
            var res = _supplierService.InsertSupplier(supplier);
            return res;
        }
        [HttpPost("suppliers")]
        public Suppliers UpdateSupplier(Suppliers supplier)
        {
            var res = _supplierService.UpdateSupplier(supplier);
            return res;
        }


    }
}
