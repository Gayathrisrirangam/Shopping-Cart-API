using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using Shopping_Cart_API.Models;
using Shopping_Cart_API.Repository;
using Shopping_Cart_API.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

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

        #region EmailService
        [HttpGet("EmailService")]

        public IActionResult SendEmail(string name, string receiver)
        {
            string body = "Thanks " + name + "!\n\n Your email id " + receiver + " is succesfully registered with" +
                " PACT \n\n Regards,\n PACT Ltd.\n Contact us: pact.onlineshop0311@gmail.com";
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse("pact.onlineshop0311@gmail.com"));
            email.To.Add(MailboxAddress.Parse(receiver));
            email.Subject = "Registration comfirmation mail-PACT";
            email.Body = new TextPart(TextFormat.Plain) { Text = body };
           
            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            smtp.Authenticate("pact.onlineshop0311@gmail.com", "tqpdurmiwakwlrev"); //email and password
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok("200");
        }
        #endregion

    }
}