using Microsoft.EntityFrameworkCore;
using Shopping_Cart_API.Data;
using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public class OrderRepo : IOrder
    {
        private ShoppingCartDbContext _ShoppingCartDb;
        public OrderRepo(ShoppingCartDbContext shoppingCartDb)
        {
            _ShoppingCartDb = shoppingCartDb;
        }

        public string DeleteOrderDetails(int OrderId) 
        {
            string msg = ""; 
            OrderT deleteOrder = _ShoppingCartDb.OrderT.Find(OrderId); 
            if (deleteOrder != null) { _ShoppingCartDb.OrderT.Remove(deleteOrder);
                _ShoppingCartDb.SaveChanges(); msg = "Deleted"; 
            }
            return msg; 
        }
        public List<OrderT> GetAllOrderDetails() 
        {
            List<OrderT> order = _ShoppingCartDb.OrderT.ToList();
            return order; 
        }
        public OrderT GetOrderDetails(int OrderId) 
        {
            OrderT order = _ShoppingCartDb.OrderT.Find(OrderId); 
            return order; 
        }
        public string SaveOrderDetails(OrderT orderDetails) 
        {
            _ShoppingCartDb.OrderT.Add(orderDetails); 
            _ShoppingCartDb.SaveChanges();
            return "Saved"; 
        }
        public string UpdateOrderDetails(OrderT orderDetails) 
        {
            _ShoppingCartDb.Entry(orderDetails).State = EntityState.Modified; 
            _ShoppingCartDb.SaveChanges(); 
            return "Updated"; 
        }
    }
}
