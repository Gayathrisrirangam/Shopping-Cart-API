using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public interface IFeedBack
    {
        public string SaveFeedDetails(FeedBackT feedback); 
        FeedBackT GetFeedDetails(int UserId); 
        List<FeedBackT> GetAllFeedDetails();
    }

}
