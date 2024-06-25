using eCommerce.Models;

namespace eCommerce.Service.Contracts
{
    public interface ICustomerService
    {
        List<Customers> GetCustomers(string searchParam);

        Customers CreateCustomer(Customers customer);
    }
}
