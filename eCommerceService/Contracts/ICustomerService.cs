using eCommerce.Models;
using eCommerce.Models.ViewModels;

namespace eCommerce.Service.Contracts
{
    public interface ICustomerService
    {
        List<Customers> GetCustomers(string searchParam);
        Customers GetCustomerById(int id);

        ResponseMessage CreateCustomer(Customers customer);

        ResponseMessage UpdateCustomer(Customers customer);
        ResponseMessage DeleteCustomer(string customerCode);
    }
}
