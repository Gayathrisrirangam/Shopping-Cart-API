using Shopping_Cart_API.Models;
using Shopping_Cart_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Services
{
    public class PaymentServices
    {
        public IPayment _payment;
        public PaymentServices(IPayment payment)
        {
            _payment = payment;
        }
        public string SaveTransaction(PaymentT Payment)
        {
            return _payment.SaveTransaction(Payment); 
        }
        public string DeleteTransaction(int TransactionId) 
        {
            return _payment.DeleteTransaction(TransactionId); 
        }
        public string UpdateTransaction(PaymentT Payment)
        {
            return _payment.UpdateTransaction(Payment); 
        }
        public PaymentT GetTransaction(int TransactionId) 
        {
            return _payment.GetTransaction(TransactionId); 
        }
        public List<PaymentT> GetAllTransaction()
        {
            return _payment.GetAllTransaction(); 
        }
    }
}
