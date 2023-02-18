using Microsoft.EntityFrameworkCore;
using Shopping_Cart_API.Data;
using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public class CartRepo : ICart
    {
        private ShoppingCartDbContext _ShoppingCartDb;

        public CartRepo(ShoppingCartDbContext shoppingCartDb)
        {
            _ShoppingCartDb = shoppingCartDb;
        }

        public string DeleteCart(int CartId)
        {
            string msg = "";
            CartT deleteCart = _ShoppingCartDb.CartT.Find(CartId);
            if (deleteCart != null)
            {
                _ShoppingCartDb.CartT.Remove(deleteCart);
                _ShoppingCartDb.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        public List<CartT> GetAllCart()
        {
            List<CartT> carts = _ShoppingCartDb.CartT.ToList();
            return carts;
        }

        public CartT GetCart(int CartId)
        {
            CartT carts = _ShoppingCartDb.CartT.Find(CartId);
            return carts;
        }

        public string SaveCart(CartT cart)
        {
            _ShoppingCartDb.CartT.Add(cart);
            _ShoppingCartDb.SaveChanges();
            return "Saved"; ;
        }

        public string UpdateCart(CartT cart)
        {
            _ShoppingCartDb.Entry(cart).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            return "Updated";
        }

        public IEnumerable<CartT> GetCartByUserID(int UserId)
        {
            var cart = _ShoppingCartDb.CartT.Where(a => a.UserId == UserId).ToList();

            return cart;
        }

        public int GetCartId(int UserId)
        {
            CartT cart = _ShoppingCartDb.CartT.FirstOrDefault(q => q.UserId == UserId);
            int CartId = cart.CartId;
            return CartId;
        }
    }
}
