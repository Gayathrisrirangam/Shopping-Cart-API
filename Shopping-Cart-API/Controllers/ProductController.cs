using Microsoft.AspNetCore.Authorization;
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
    public class ProductController : ControllerBase
    {
        private ProductService _productServices;

        public ProductController(ProductService Product)
        {
            _productServices = Product;
        }

        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct(ProductT Product)
        {
            return Ok(_productServices.SaveProduct(Product));
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int ProductId)
        {
            return Ok(_productServices.DeleteProduct(ProductId));
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProducte(ProductT Product)
        {
            return Ok(_productServices.UpdateProduct(Product));
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int ProductId)
        {
            return Ok(_productServices.GetProduct(ProductId));
        }

        [HttpGet("GetAllProduct()")]
        public List<ProductT> GetAllProduct()
        {
            return _productServices.GetAllProduct();
        }
    }
}
