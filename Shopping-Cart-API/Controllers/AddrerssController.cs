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
    public class AddrerssController : ControllerBase
    {
        private AddressServices _addresServices;
        public AddrerssController(AddressServices addressServices)
        {
            _addresServices = addressServices;
        }
        [HttpPost("SaveAddress")] 
        public IActionResult SaveAddress(AddressT AddressT) 
        {
            return Ok(_addresServices.SaveAddress(AddressT)); 
        }
        [HttpDelete("DeleteAddress")] 
        public IActionResult DeleteAddress(int AddressId)
        {
            return Ok(_addresServices.DeleteAddress(AddressId)); 
        }
        [HttpPut("UpdateAddress")]
        public IActionResult UpdateAddress(AddressT AddressT)
        {
            return Ok(_addresServices.UpdateAddress(AddressT)); 
        }
        [HttpGet("GetAddress")] 
        public IActionResult GetAddress(int AddressId) 
        {
            return Ok(_addresServices.GetAddress(AddressId)); 
        }
        [HttpGet("GetUserAddress")] 
        public IActionResult GetUserAddress(int UserId)
        {
            return Ok(_addresServices.GetUserAddress(UserId)); 
        }
        [HttpGet("GetAllAddress")]
        public List<AddressT> GetAllAddress()
        {
            return _addresServices.GetAllAddress(); 
        }
    }
}
