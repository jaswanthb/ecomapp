using eCommerce.Models;
using eCommerce.Models.ViewModels;
using eCommerce.Service.Contracts;
using eCommerceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
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

        public OrdersVM GetOrderById(int id)
        {

            var order = _dbContext.Orders
                          .Include(o => o._OrderDetails)
                          .FirstOrDefault(o => o.OrderID == id);
            if (order != null)
            {
                var orderVM = new OrdersVM()
                {
                    OrderID = order.OrderID,
                    OrderDate = order.OrderDate,
                    CustomerID = order.CustomerID,
                    RequiredDate = order.RequiredDate,
                    ShippedDate = order.ShippedDate,
                    ShipVia = order.ShipVia,
                    Freight = order.Freight,
                    ShipName = order.ShipName,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipRegion = order.ShipRegion,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipCountry = order.ShipCountry,
                };
                orderVM.OrderDetails = new List<OrderDetailsVM>();
                foreach (var od in order._OrderDetails)
                {
                    orderVM.OrderDetails.Add(
                        new OrderDetailsVM()
                        {
                            OrderDetailsId = od.OrderDetailsId,
                            OrderID = od.OrderID,
                            ProductID = od.ProductID,
                            UnitPrice = od.UnitPrice,
                            Quantity = od.Quantity,
                            Discount = od.Discount
                        }
                        );

                }


                return orderVM;

            }
            return null;
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

        public Orders InsertOrder(OrdersVM orders)
        {
            Orders insertOrder = new Orders();
            insertOrder.OrderID = orders.OrderID;
            insertOrder.CustomerID = orders.CustomerID;
            insertOrder.OrderDate = orders.OrderDate;
            insertOrder.RequiredDate = orders.RequiredDate;
            insertOrder.ShippedDate = orders.ShippedDate;
            insertOrder.ShipVia = orders.ShipVia;
            insertOrder.Freight = orders.Freight;
            insertOrder.ShipName = orders.ShipName;
            insertOrder.ShipAddress = orders.ShipAddress;
            insertOrder.ShipCity = orders.ShipCity;
            insertOrder.ShipRegion = orders.ShipRegion;
            insertOrder.ShipPostalCode = orders.ShipPostalCode;
            insertOrder.ShipCountry = orders.ShipCountry;

            var insertOrderDetails = new List<OrderDetails>();
            foreach (var order in orders.OrderDetails)
            {
                var orderDetails = new OrderDetails();
                orderDetails.OrderDetailsId = order.OrderDetailsId;
                orderDetails.OrderID = order.OrderID;
                orderDetails.ProductID = order.ProductID;
                orderDetails.UnitPrice = order.UnitPrice;
                orderDetails.Quantity = order.Quantity;
                orderDetails.Discount = order.Discount;
                insertOrderDetails.Add(orderDetails);
            }
            insertOrder._OrderDetails = insertOrderDetails;
            _dbContext.Orders.Add(insertOrder);
            _dbContext.SaveChanges();
            return insertOrder;
        }

        public Orders UpdateOrder(OrdersVM orders)
        {
            throw new NotImplementedException();
        }


    }
}
