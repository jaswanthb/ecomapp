using eCommerce.Models;
using eCommerce.Models.ViewModels;
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

        OrdersVM GetOrderById(int id);

        Orders InsertOrder(OrdersVM orders);
        Orders UpdateOrder(OrdersVM orders);
        ResponseMessage DeleteOrder(DeleteOrderVM deleteOrder);
    }
}
