using Shopping_Cart_API.Models;
using Shopping_Cart_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Services
{
    public class FeedBackServices
    {
        public IFeedBack _feedbackRepository;
        public FeedBackServices(IFeedBack feedbackRepo)
        {
            _feedbackRepository = feedbackRepo;
        }
        public string SaveFeedDetails(FeedBackT feedback)
        {
            return _feedbackRepository.SaveFeedDetails(feedback); 
        }
        public List<FeedBackT> GetAllFeedDetails() 
        {
            return _feedbackRepository.GetAllFeedDetails(); 
        }
    }
}
