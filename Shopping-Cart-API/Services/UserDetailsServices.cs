using Shopping_Cart_API.Models;
using Shopping_Cart_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Services
{
    public class UserDetailsServices
    {
        private IUser _userDetailsRepository;

        public UserDetailsServices(IUser userDetailsRepository )
        {
            _userDetailsRepository = userDetailsRepository;
        }

        public string DeleteUserDetails(int UserId)
        {
            return _userDetailsRepository.DeleteUserDetails(UserId);
        }
        public string UpdateUserDetails(UserDetailsT userDetails)
        {
            return _userDetailsRepository.UpdateUserDetails(userDetails);
        }
        public UserDetailsT GetUserDetails(int UserId)
        {
            return _userDetailsRepository.GetUserDetails(UserId);
        }
        public List<UserDetailsT> GetAllUserDetails()
        {
            return _userDetailsRepository.GetAllUserDetails();
        }
        public string SaveUserDetails(UserDetailsT userDetails)
        {
            return _userDetailsRepository.SaveUserDetails(userDetails);
        }
        public UserDetailsT GetUserbyEmail(string EmailId)
        {
            return _userDetailsRepository.GetUserbyEmail(EmailId);
        }

        

    }
}
