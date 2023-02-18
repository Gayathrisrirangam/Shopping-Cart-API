using Microsoft.EntityFrameworkCore;
using Shopping_Cart_API.Data;
using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public class PaymentRepo : IPayment
    {
        private ShoppingCartDbContext _ShoppingCartDb;
        public PaymentRepo(ShoppingCartDbContext shoppingCartDb)
        {
            _ShoppingCartDb = shoppingCartDb;
        }
        public string DeleteTransaction(int TransactionId) 
        {
            string msg = ""; 
            PaymentT deleteTransaction = _ShoppingCartDb.PaymentT.Find(TransactionId); 
            if (deleteTransaction != null) 
            {
                _ShoppingCartDb.PaymentT.Remove(deleteTransaction); 
                _ShoppingCartDb.SaveChanges(); msg = "Deleted"; 
            }
            return msg; 
        }
        public List<PaymentT> GetAllTransaction() 
        {
            List<PaymentT> transactions = _ShoppingCartDb.PaymentT.ToList(); 
            return transactions; 
        }
        public PaymentT GetTransaction(int TransactionId) 
        {
            PaymentT transaction = _ShoppingCartDb.PaymentT.Find(TransactionId); 
            return transaction; 
        }
        public string SaveTransaction(PaymentT Payment) 
        {
            _ShoppingCartDb.PaymentT.Add(Payment); 
            _ShoppingCartDb.SaveChanges(); 
            return "Saved"; 
        }
        public string UpdateTransaction(PaymentT Payment) 
        {
            _ShoppingCartDb.Entry(Payment).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges(); 
            return "Updated"; 
        }
    }
}
