using Microsoft.EntityFrameworkCore;
using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Data
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {

        }
        public DbSet<UserDetailsT> UserDetailsT { get; set; }
        public DbSet<ProductT> ProductT { get; set; }
        public DbSet<PaymentT> PaymentT { get; set; }
        public DbSet<CartT> CartT { get; set; }
        public DbSet<OrderT> OrderT { get; set; }
        public DbSet<AddressT> AddressT { get; set; }
        public DbSet<FeedBackT> feedbackT { get; set; }         
        
    }
}
