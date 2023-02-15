using Microsoft.EntityFrameworkCore;
using Shopping_Cart_API.Data;
using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public class UserRepo : IUser
    {
        private ShoppingCartDbContext _ShoppingCartDb;

        #region UserRepo
        public UserRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        #endregion

        #region DeleteUserDetails
        /// <summary> 
        ///  Function to Delete user details
        /// </summary>
        public string DeleteUserDetails(int UserId)
        {
            string msg = "";
            UserDetailsT deleteUser = _ShoppingCartDb.UserDetailsT.Find(UserId);
            try
            {
                if (deleteUser != null)
                {
                    _ShoppingCartDb.UserDetailsT.Remove(deleteUser);
                    _ShoppingCartDb.SaveChanges();
                    msg = "User Deleted";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        #endregion          
        
        #region GetAllUserDetails
        /// <summary>
        /// Function to get all users details
        /// </summary>
      
        public List<UserDetailsT> GetAllUserDetails()
        {
            try
            {
                List<UserDetailsT> user = _ShoppingCartDb.UserDetailsT.ToList();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion    
        
        #region GetuserDetails
        /// <summary>
                /// This Function Will Give all the user Details
                /// </summary>               
        public UserDetailsT GetUserDetails(int UserId)
        {
            try
            {
                UserDetailsT user = _ShoppingCartDb.UserDetailsT.Find(UserId);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion        
        
        #region SaveUserDetails
        /// <summary>
                /// Store the user Details
                /// </summary>
        public string SaveUserDetails(UserDetailsT userDetails)
        {
            string result = string.Empty;
            try
            {
                _ShoppingCartDb.UserDetailsT.Add(userDetails);
                _ShoppingCartDb.SaveChanges();
                result = "Registration Successful";
            }
            catch (Exception e) { }
            finally { }
            return result;
        }
        #endregion         

        #region UpdateUserDetails
        /// <summary>
                /// UpdateUser Details
                /// </summary>
        public string UpdateUserDetails(UserDetailsT userDetails)
        {
            try
            {
                _ShoppingCartDb.Entry(userDetails).State = EntityState.Modified;
                _ShoppingCartDb.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Updated";
        }
        #endregion        
        
        #region GetUserByEmail
        /// <summary>
                /// Method to get the user by Email
                /// </summary>
        public UserDetailsT GetUserbyEmail(string EmailId)
        {
            UserDetailsT user = null;
            try
            {
                user = _ShoppingCartDb.UserDetailsT.FirstOrDefault(q => q.EmailId == EmailId);

            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }
        #endregion

        #region Login
        public async Task LoginUser(LoginModel userDetails)
        {
            try
            {
                var UserDetailsT = await _ShoppingCartDb.UserDetailsT.FirstOrDefaultAsync(x => x.EmailId == userDetails.EmailId && x.Password == userDetails.Password);
            }
            catch
            {
                throw;
            }
        }
        #endregion

    }
}
