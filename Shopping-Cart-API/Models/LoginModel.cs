using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email can not be empty")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }
    }
}
