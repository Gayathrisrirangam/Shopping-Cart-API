using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shopping_Cart_API.Models;
using Shopping_Cart_API.Repository;
using Shopping_Cart_API.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private UserDetailsServices _userDetailsServices;

        #region UserdetailsController
        /// <summary>
        /// This Is Usercontroller Constructor
        /// </summary>
        public UserDetailsController(UserDetailsServices userDetailsServices)
        {
            _userDetailsServices = userDetailsServices;
        }
        #endregion

        #region GetUserbyEmail
        [HttpGet("GetUserbyEmail")]
        public IActionResult GetUserbyEmail(string EmailId)
        {
            return Ok(_userDetailsServices.GetUserbyEmail(EmailId));
        }
        #endregion

        #region GetallUserDetails
        /// <summary>
                /// function for getting all user details
                /// </summary>
        [HttpGet("GetAllUserDetails")]
        public List<UserDetailsT> GetAllUserDetails()
        {
            return _userDetailsServices.GetAllUserDetails();
        }
        #endregion

        #region DeleteUseretails
        /// <summary>
                /// function for deleting user details
                /// </summary>

        [HttpDelete("DeleteUserDetails")]
        public IActionResult DeleteUserDetails(int UserId)
        {
            return Ok(_userDetailsServices.DeleteUserDetails(UserId));
        }
        #endregion

        #region GetUserDetails
        /// <summary>
                /// Controller class of Getuserdetails
                /// </summary>

        [HttpGet("GetUserDetailsbyID")]
        public IActionResult GetUserDetails(int UserId)
        {
            return Ok(_userDetailsServices.GetUserDetails(UserId));
        }
        #endregion

        #region SaveUserDetails
        /// <summary>
                /// Controller class of SaveuserDetails
                /// </summary>

        [HttpPost("RegisterUser")]
        public IActionResult SaveUserDetails(UserDetailsT userDetails)
        {
            _userDetailsServices.SaveUserDetails(userDetails);
            return Ok(new { Message = "Registration Successfull" });
        }
        #endregion

        #region UpdateUserDetails
        /// <summary>
                /// Updating user details
                /// </summary>

        [HttpPut("UpdateUserDetails")]
        public IActionResult UpdateUserDetails(UserDetailsT userDetails)
        {
            return Ok(_userDetailsServices.UpdateUserDetails(userDetails));
        }
        #endregion

        /// <summary>
                /// User Login
                /// </summary>
        #region Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = _userDetailsServices.GetUserbyEmail(model.EmailId);
            if (user != null && model.Password == user.Password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PNM4t3NEYbOd1SGe")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { 
                    token,
                    Message=
                    "Login successful"
                } );
                //return Ok("Login Successful");
            }
            else
            {
                return BadRequest(new { message = "Email or Password is incorrect." });
            }


        }
        #endregion

    }
}