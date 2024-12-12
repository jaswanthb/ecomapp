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
        //private readonly IDistributedCache _distributedCache;
        public SupplierService(eCommerceContext dbContext /*IDistributedCache distributedCache*/)
        {
            _dbContext = dbContext;
            //_distributedCache = distributedCache;
        }

        public List<Suppliers> GetSuppliers(string searchString)
        {
            //var supplierData = _distributedCache.GetData<List<Suppliers>>("suppliers");
            //if (supplierData is null)
            //{
               var supplierData = _dbContext.Suppliers.Where(s => s.CompanyName.Contains(searchString)
                                                 || s.ContactName.Contains(searchString)
                                                 || s.City.Contains(searchString))
                                         .ToList();

                //_distributedCache.SetData("suppliers", supplierData, DateTimeOffset.Now.AddMinutes(5.0));
            //}
            return supplierData;
        }

        public Suppliers GetSupplierById(int id)
        {
            Suppliers sup = _dbContext.Suppliers.First(s => s.SupplierID == id);    
            return sup ?? new Suppliers();
        }

        public ResponseMessage InsertSupplier(Suppliers supplier)
        {
            ResponseMessage supplierInsertMessage = new ResponseMessage();
            try
            {
                var res = _dbContext.Suppliers.Any(s => s.SupplierID == supplier.SupplierID);
                if (!res)
                {
                    _dbContext.Suppliers.Add(supplier);
                    _dbContext.SaveChanges();
                    supplierInsertMessage.IsError = false;
                    return supplierInsertMessage;
                }
                else
                {
                    supplierInsertMessage.IsError = true;
                    supplierInsertMessage.ErrorMessage = $"Supplier already exists with given Supplier Id {supplier.SupplierID}";
                    return supplierInsertMessage;
                }
            }
            catch
            {
                supplierInsertMessage.IsError = true;
                supplierInsertMessage.ErrorMessage = $"Something went wrong while inserting supplier {supplier.SupplierID}";
                return supplierInsertMessage;
            }

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
