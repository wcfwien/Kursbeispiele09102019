using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ta.Data;

namespace TravelAgency.ServiceContract
{
    [ServiceContract]
    public interface ITravelService
    {
        [OperationContract]
        [WebGet(UriTemplate = "sights")]
        List<Sight> GetSights();

        [OperationContract]
        [WebGet(UriTemplate = "sights?json", ResponseFormat = WebMessageFormat.Json)]
        List<Sight> GetSightsJson();

        [OperationContract]
        [WebGet(UriTemplate = "review/{sightId}/reviews")]
        List<Review> GetReviews(int sightId);

        [OperationContract]
        [WebInvoke(UriTemplate = "addreview", Method = "POST")]
        void AddReview(Review review);
    }
}