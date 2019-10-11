using System.Collections.Generic;
using System.ServiceModel;
using Ta.Business;
using Ta.Data;
using TravelAgency.ServiceContract;

namespace TravelAgency
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, 
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class TravelService : ITravelService
    {
        public void AddReview(Review review)
        {
            var reviewManager = new ReviewManager();
            reviewManager.AddReview(review);
        }

        public List<Review> GetReviews(int sightId)
        {
            var reviewManager = new ReviewManager();
            return reviewManager.GetReviewsForSight(sightId);
        }

        public List<Sight> GetSights()
        {
            var reviewManager = new ReviewManager();
            return reviewManager.GetSights();
        }

        public List<Sight> GetSightsJson()
        {
            var reviewManager = new ReviewManager();
            return reviewManager.GetSights();
        }
    }
}
