using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping_Cart_API.Services;
using Shopping_Cart_API.Models;

namespace Shopping_Cart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private CartServices _cartService;
        public CartController(CartServices cartservice)
        {
            _cartService = cartservice;
        }

        [HttpPost("SaveCart")] 
        public IActionResult SaveCart(CartT cart)
        {
            return Ok(_cartService.SaveCart(cart)); 
        }
        [HttpDelete("DeleteCart")] 
        public IActionResult DeleteCart(int CartId) 
        {
            return Ok(_cartService.DeleteCart(CartId)); 
        }
        [HttpPut("UpdateCart")]
        public IActionResult UpdateCart(CartT cart) 
        {
            return Ok(_cartService.UpdateCart(cart)); 
        }
        [HttpGet("GetCart")] 
        public IActionResult GetCart(int CartId) 
        {
            return Ok(_cartService.GetCart(CartId)); 
        }
        [HttpGet("GetAllCart")]
        public List<CartT> GetAllCart() 
        {
            return _cartService.GetAllCart(); 
        }
        [HttpGet("GetCartHistory")]
        public IActionResult GetCartByUserID(int UserId)
        {
            return Ok(_cartService.GetCartByUserID(UserId)); 
        }
        [HttpGet("GetCartId")] 
        public IActionResult GetCartId(int UserId) 
        {
            return Ok(_cartService.GetCartId(UserId)); 
        }
    }
}
