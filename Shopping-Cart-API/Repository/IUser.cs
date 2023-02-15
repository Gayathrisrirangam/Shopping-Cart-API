using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public interface IUser
    {
        public string SaveUserDetails(UserDetailsT userDetails);
        public string UpdateUserDetails(UserDetailsT userDetails);
        public string DeleteUserDetails(int UserId);

        UserDetailsT GetUserDetails(int UserId);

        List<UserDetailsT> GetAllUserDetails();
        UserDetailsT GetUserbyEmail(string EmailId);

        Task LoginUser(LoginModel userDetails);
    }
}

