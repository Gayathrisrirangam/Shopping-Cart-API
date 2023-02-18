using Shopping_Cart_API.Models;
using Shopping_Cart_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Services
{
    public class OrderServices
    {
        private IOrder _orderDetailsRepository;
        public OrderServices(IOrder orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        
        public string SaveOrderDetails(OrderT orderDetails) 
        {            
            return _orderDetailsRepository.SaveOrderDetails(orderDetails);
        }
        public string DeleteOrderDetails(int OrderId) 
        {
            return _orderDetailsRepository.DeleteOrderDetails(OrderId); 
        }
        public string UpdateOrderDetails(OrderT orderDetails) 
        {
            return _orderDetailsRepository.UpdateOrderDetails(orderDetails); 
        }
        public OrderT GetOrderDetails(int OrderId) 
        {
            return _orderDetailsRepository.GetOrderDetails(OrderId); 
        }
        public List<OrderT> GetAllOrderDetails() 
        {
            return _orderDetailsRepository.GetAllOrderDetails(); 
        }


    }
}
