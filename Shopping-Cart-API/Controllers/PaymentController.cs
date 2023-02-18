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
    public class PaymentController : ControllerBase
    {
        public PaymentServices _paymentService;
        public PaymentController(PaymentServices paymentservice)
        {
            _paymentService = paymentservice;
        }
        [HttpPost("SaveTransaction")] 
        public IActionResult SaveTransaction(PaymentT Payment) 
        {
            return Ok(_paymentService.SaveTransaction(Payment)); 
        }
        [HttpPost("DeleteTransaction")] 
        public IActionResult DeleteTransaction(int CartId)
        {
            return Ok(_paymentService.DeleteTransaction(CartId)); 
        }
        [HttpPost("UpdateTransaction")]
        public IActionResult UpdateTransaction(PaymentT transaction) 
        {
            return Ok(_paymentService.UpdateTransaction(transaction)); 
        }
        [HttpGet("GetTransaction")] 
        public IActionResult GetTransaction(int TransactionId) 
        {
            return Ok(_paymentService.GetTransaction(TransactionId)); 
        }
        [HttpGet("GetAllTransaction")]
        public List<PaymentT> GetAllTransaction() 
        {
            return _paymentService.GetAllTransaction(); 
        }
    }
}
