using eCommerce.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using eCommerce.Models;
using eCommerce.Models.ViewModels;

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

        [HttpGet]
        [Route("suppliers/{id}")]

        public Suppliers GetSupplier(int id)
        {
            return _supplierService.GetSupplierById(id);
        }

        [HttpPost("Suppliers")]
        public ResponseMessage InsertSupplier(Suppliers supplier)
        {
            var res = _supplierService.InsertSupplier(supplier);
            return res;
        }
        [HttpPut("suppliers")]
        public ResponseMessage UpdateSupplier(Suppliers supplier)
        {
            var res = _supplierService.UpdateSupplier(supplier);
            return res;
        }
        [HttpDelete("suppliers")]
        public ResponseMessage DeleteSupplier(int supplierId)
        {
            var res = _supplierService.DeleteSupplier(supplierId);
            return res;
        }


    }
}
