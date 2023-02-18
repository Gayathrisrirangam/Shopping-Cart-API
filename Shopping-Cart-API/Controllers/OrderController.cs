using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart_API.Models;
using Shopping_Cart_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderServices _orderServices;
        public OrderController(OrderServices userorderservices)
        {
            _orderServices = userorderservices;
        }
        [HttpPost("SaveOrderDetails")] 
        public IActionResult SaveOrderDetails(OrderT orderDetails)
        {
            return Ok(_orderServices.SaveOrderDetails(orderDetails)); 
        }
        [HttpDelete("DeleteOrderDetails")] 
        public IActionResult DeleteOrderDetails(int OrderId) 
        {
            return Ok(_orderServices.DeleteOrderDetails(OrderId)); 
        }
        [HttpPut("UpdateOrderDetails")] 
        public IActionResult UpdateOrderDetails(OrderT orderDetails) 
        {
            return Ok(_orderServices.UpdateOrderDetails(orderDetails)); 
        }
        [HttpGet("GetOrderDetails")] 
        public IActionResult GetOrderDetails(int OrderId) 
        {
            return Ok(_orderServices.GetOrderDetails(OrderId)); 
        }
        [HttpGet("GetAllOrderDetails()")]
        public List<OrderT> GetAllOrderDetails() 
        {
            return _orderServices.GetAllOrderDetails(); 
        }
    }
}
