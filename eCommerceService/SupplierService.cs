using eCommerce.Models;
using eCommerce.Service.Contracts;
using eCommerceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly eCommerceContext _dbContext;
        public SupplierService(eCommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Suppliers> GetSuppliers(string searchString)
        {
            return _dbContext.Suppliers.Where(s => s.CompanyName.Contains(searchString)
                                                || s.ContactName.Contains(searchString)
                                                || s.City.Contains(searchString))
                                        .ToList();
        }
        public Suppliers InsertSupplier(Suppliers supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();
            return supplier;
        }

    }
}
