using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BeispielService
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface ISampleService
    {
        [OperationContract]
        void TestMethod1();

        [OperationContract(IsOneWay = true)]
        void TestMethod2();

        [OperationContract(IsOneWay = true)]
        void TestMethod3();
    }

    [ServiceContract]
    public interface ICallBack 
    {
        [OperationContract(IsOneWay = true)]
        void NotifyClient(string message);
    }
}
