using Shopping_Cart_API.Data;
using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public class FeedBackRepo : IFeedBack
    {
        private ShoppingCartDbContext shoppingCartDb;
        public FeedBackRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            shoppingCartDb = shoppingCartDbContext;
        }

        public List<FeedBackT> GetAllFeedDetails() 
        {
            List<FeedBackT> feed = shoppingCartDb.feedbackT.ToList(); 
            return feed; 
        }
        public FeedBackT GetFeedDetails(int UserId) 
        {
            FeedBackT feed = shoppingCartDb.feedbackT.Find(UserId);
            return feed; 
        }
        public string SaveFeedDetails(FeedBackT feedback) 
        {
            shoppingCartDb.feedbackT.Add(feedback);
            shoppingCartDb.SaveChanges(); 
            return "Saved"; 
        }
    }
}
