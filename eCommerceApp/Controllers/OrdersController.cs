using eCommerce.Models;
using eCommerce.Service;
using eCommerce.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerce.Models.ViewModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerce.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public List<Orders> Get(string searchString)
        {
            return _orderService.GetOrders(searchString);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public OrdersVM GetOrderById(int id)
        {
            return _orderService.GetOrderById(id);
        }



        // POST api/<OrdersController>
        [HttpPost]
        public Orders InsertOrder([FromBody] OrdersVM order)
        {
          return  _orderService.InsertOrder(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut]
        public Orders UpdateOrder([FromBody] OrdersVM order)
        {
            return _orderService.UpdateOrder(order);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete]
        public ResponseMessage DeleteOrder(DeleteOrderVM deleteOrder)
        {
            return _orderService.DeleteOrder(deleteOrder);
        }
    }
}
