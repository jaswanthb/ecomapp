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
        public ResponseMessage DeleteOrder(DeleteOrderVM deleteOrder)
        {
            ResponseMessage deleteOrderResp = new ResponseMessage();
            try
            {
                var order = _dbContext.Orders.FirstOrDefault(o => o.OrderID == deleteOrder.OrderID);
                if (order != null)
                {
                    if (!deleteOrder.IsActive)
                    {
                        order.IsActive = false;
                        foreach (var od in order._OrderDetails)
                        {
                            od.IsActive = false;
                        }
                    }
                    else
                    {
                        foreach (var k in deleteOrder.OrderDetails)
                        {
                            if (order._OrderDetails.Any(od => od.OrderDetailsId == k.Key) && k.Value == false)
                            {
                                order._OrderDetails.FirstOrDefault(ods => ods.OrderDetailsId == k.Key).IsActive = false;
                            }
                        }
                    }
                    _dbContext.Orders.Update(order);
                    _dbContext.SaveChanges();

                    var orderConditional = _dbContext.Orders.FirstOrDefault(o => o.OrderID == deleteOrder.OrderID);
                    if (orderConditional._OrderDetails.Count(o => o.IsActive == false) == orderConditional._OrderDetails.Count)
                    {
                        orderConditional.IsActive = false;
                        _dbContext.Orders.Update(orderConditional);
                        _dbContext.SaveChanges();
                    }
                   

                    deleteOrderResp.IsError = false;
                    return deleteOrderResp;
                }
                deleteOrderResp.IsError = true;
                deleteOrderResp.ErrorMessage = $"The order with order id {deleteOrder.OrderID} does not exist";
                return deleteOrderResp;
            }
            catch(Exception ex)
            {
                deleteOrderResp.IsError = true;
                deleteOrderResp.ErrorMessage = $"Something Went Wrong while delete";
                return deleteOrderResp;
            }
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
            Orders updateOrder = new Orders();
            updateOrder.OrderID = orders.OrderID;
            updateOrder.CustomerID = orders.CustomerID;
            updateOrder.OrderDate = orders.OrderDate;
            updateOrder.RequiredDate = orders.RequiredDate;
            updateOrder.ShippedDate = orders.ShippedDate;
            updateOrder.Freight = orders.Freight;
            updateOrder.ShipName = orders.ShipName;
            updateOrder.ShipAddress = orders.ShipAddress;
            updateOrder.ShipCity = orders.ShipCity;
            updateOrder.ShipRegion = orders.ShipRegion;
            updateOrder.ShipPostalCode = orders.ShipPostalCode;
            updateOrder.ShipCountry = orders.ShipCountry;
            updateOrder.IsActive = orders.IsActive; 

            var updateOrderDetails = new List<OrderDetails>();
            foreach(var order in orders.OrderDetails)
            {
                var orderDetails = new OrderDetails();
                orderDetails.OrderID = order.OrderID;
                orderDetails.OrderDetailsId = order.OrderDetailsId;
                orderDetails.ProductID = order.ProductID;
                orderDetails.Quantity = order.Quantity;
                orderDetails.IsActive = order.IsActive;
                updateOrderDetails.Add(orderDetails);
            }
            updateOrder._OrderDetails = updateOrderDetails;
            _dbContext.Orders.Update(updateOrder);
            _dbContext.SaveChanges();
            return updateOrder;
        }


    }
}
