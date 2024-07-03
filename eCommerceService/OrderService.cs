using eCommerce.Models;
using eCommerce.Service.Contracts;
using eCommerceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public class OrderService : IOrderService
    {
        private readonly eCommerceContext _dbContext;
        public OrderService(eCommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Orders GetOrderById(int id)
        {
            var order = _dbContext.Orders
                          .Include(o => o._OrderDetails)
                          .FirstOrDefault(o => o.OrderID == id);

            return order;

        }
        public bool DeleteOrder(Orders orders)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetOrders(string searchString)
        {
            var orders = _dbContext.Orders.AsNoTracking().ToList();//.Include(o => o._OrderDetails).ToList();

            return orders;
        }

        public Orders InsertOrder(Orders orders)
        {
            throw new NotImplementedException();
        }

        public Orders UpdateOrder(Orders orders)
        {
            throw new NotImplementedException();
        }


    }
}
