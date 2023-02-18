using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public interface IAddress
    {
        public string SaveAddress(AddressT AdressT); 
        public string UpdateAddress(AddressT AddressT);
        public string DeleteAddress(int AddressId); 
        AddressT GetAddress(int AddressId); 
        AddressT GetUserAddress(int UserId); List<AddressT> GetAllAddress();
    }
}
