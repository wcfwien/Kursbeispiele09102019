using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestDemo
{
    [ServiceContract]
    public interface IAutoService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Autos", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        List<Auto> GetAutos();
    }

    [DataContract]
    public class Auto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}