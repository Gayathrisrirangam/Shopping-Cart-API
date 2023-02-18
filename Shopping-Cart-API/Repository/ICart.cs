using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public interface ICart
    {
        public string SaveCart(CartT cart); 
        public string UpdateCart(CartT cart); 
        public string DeleteCart(int CartId); 
        CartT GetCart(int CartId); List<CartT> GetAllCart(); 
        public IEnumerable<CartT> GetCartByUserID(int UserId); 
        public int GetCartId(int UserId);
    }
}
