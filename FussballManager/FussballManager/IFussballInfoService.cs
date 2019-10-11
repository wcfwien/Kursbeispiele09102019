using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FussballManager
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFussballInfoService" in both code and config file together.
    [ServiceContract]
    public interface IFussballInfoService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/PlayerDetail/{PlayerId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetPlayerById(string PlayerId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/create",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        void CreatePlayer(Player player);
    }

    /// <summary>
    /// Spielerklasse
    /// </summary>
    [DataContract]
    public class Player 
    {
        /// <summary>
        /// Trikotnummer
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Spielername
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
