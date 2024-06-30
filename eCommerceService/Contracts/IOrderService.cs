using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Contracts
{
    public interface IOrderService
    {
        List<Orders> GetOrders(string searchString);
        Orders InsertOrder(Orders orders);
        Orders UpdateOrder(Orders orders);
        bool DeleteOrder(Orders orders);
    }
}
