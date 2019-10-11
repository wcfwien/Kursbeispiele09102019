using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.Service
{
    public interface IAutoService
    {
        [OperationContract]
        [WebGet(UriTemplate = "autos", ResponseFormat = WebMessageFormat.Json)]
        List<Auto> GetAllAutos();
    }
}
