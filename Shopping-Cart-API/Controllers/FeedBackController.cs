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
    public class FeedBackController : ControllerBase
    {
        private FeedBackServices _FeedBackService;
        public FeedBackController(FeedBackServices feedBackServices)
        {
            _FeedBackService = feedBackServices;
        }
        [HttpPost("SaveFeedDetails")]
        public IActionResult SaveFeedDetails(FeedBackT feedback)
        {
            return Ok(_FeedBackService.SaveFeedDetails(feedback));
        }
        [HttpGet("GetAllFeedDetails()")] 
        public List<FeedBackT> GetAllFeedDetails() 
        {
            return _FeedBackService.GetAllFeedDetails(); 
        }

    }
}
