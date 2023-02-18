using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public interface IOrder
    {
        public string SaveOrderDetails(OrderT orderDetails); 
        public string UpdateOrderDetails(OrderT orderDetails); 
        public string DeleteOrderDetails(int OrderId); 
        OrderT GetOrderDetails(int OrderId);
        List<OrderT> GetAllOrderDetails();
    }
}
