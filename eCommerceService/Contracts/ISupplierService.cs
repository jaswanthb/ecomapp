using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Contracts
{
    public interface ISupplierService
    {
        List<Suppliers> GetSuppliers(string searchString);

        public Suppliers InsertSupplier(Suppliers suppier);

        public Suppliers UpdateSupplier(Suppliers supplier);

        public Suppliers DeleteSupplier(Suppliers supplier);

    }
}
