using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public interface IPayment
    {
        public string SaveTransaction(PaymentT Payment); 
        public string UpdateTransaction(PaymentT Payment); 
        public string DeleteTransaction(int TransactionId); 
        PaymentT GetTransaction(int TransactionId); 
        List<PaymentT> GetAllTransaction();
    }
}
