using eCommerce.Models;
using eCommerce.Service;
using eCommerce.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public Orders GetOrderById(int id)
        {
            return _orderService.GetOrderById(id);
        }



        // POST api/<OrdersController>
        [HttpPost]
        public Orders Post([FromBody] Orders order)
        {
          return  _orderService.InsertOrder(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
