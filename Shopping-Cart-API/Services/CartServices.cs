using Shopping_Cart_API.Models;
using Shopping_Cart_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Services
{
    public class CartServices
    {
        private ICart _cartRepository;

        public CartServices(ICart cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public string SaveCart(CartT cart) 
        { 
            return _cartRepository.SaveCart(cart);
        }
        public string DeleteCart(int CartId)
        { 
            return _cartRepository.DeleteCart(CartId); 
        }
        public string UpdateCart(CartT cart) 
        {
            return _cartRepository.UpdateCart(cart); 
        }
        public CartT GetCart(int CartId)
        { 
            return _cartRepository.GetCart(CartId); 
        }
        public List<CartT> GetAllCart() 
        { 
            return _cartRepository.GetAllCart(); 
        }
        public IEnumerable<CartT> GetCartByUserID(int UserId)
        {
            return _cartRepository.GetCartByUserID(UserId); 
        }
        public int GetCartId(int UserId) 
        {
            return _cartRepository.GetCartId(UserId); 
        }
    }
}
