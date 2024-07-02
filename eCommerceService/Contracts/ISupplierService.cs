using eCommerce.Models;
using eCommerce.Models.ViewModels;
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

        ResponseMessage InsertSupplier(Suppliers suppier);

        ResponseMessage UpdateSupplier(Suppliers supplier);

        ResponseMessage DeleteSupplier(int supplierId);

    }
}
