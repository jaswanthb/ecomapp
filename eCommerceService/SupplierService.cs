using eCommerce.Models;
using eCommerce.Models.ViewModels;
using eCommerce.Service.Contracts;
using eCommerceRepository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
        public ResponseMessage InsertSupplier(Suppliers supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();
            return null;
        }
        public ResponseMessage UpdateSupplier(Suppliers supplier)
        {
            ResponseMessage updateMessage = new ResponseMessage();
            try
            {
                if (supplier != null)
                {

                    _dbContext.Suppliers.Update(supplier);
                    _dbContext.SaveChanges();
                    updateMessage.IsError = false;
                    return updateMessage;
                }
                else
                {
                    updateMessage.IsError = true;
                    updateMessage.ErrorMessage = $"Supplier With {supplier} Does not Exist";
                    return updateMessage;
                }
            }
            catch (Exception ex)
            {
                updateMessage.IsError = true;
                updateMessage.ErrorMessage = $"Something went wrong when updating the supplier{supplier} ";
                return updateMessage;
            }
        }

        public ResponseMessage DeleteSupplier(int supplierId)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var sup = _dbContext.Suppliers.FirstOrDefault(s => s.SupplierID == supplierId);
                if (sup != null)
                {
                    sup.IsActive = false;
                    _dbContext.Suppliers.Update(sup);
                    _dbContext.SaveChanges();
                    responseMessage.IsError = false;
                    return responseMessage;
                }
                else
                {
                    responseMessage.IsError = true;
                    responseMessage.ErrorMessage = $"Supplier With {supplierId} Does not Exist";
                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                responseMessage.IsError = true;
                responseMessage.ErrorMessage = $"Something went wrong when deleting the Supplier {supplierId}";
                return responseMessage;
            }
        }
    }
}
