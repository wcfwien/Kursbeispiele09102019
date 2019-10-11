using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    [ServiceContract]
    public interface IRechnerService
    {
        [OperationContract]
        double Addieren(Rechner rechner);

        [OperationContract]
        double Subtrahieren(double zahl1, double zahl2);

        [OperationContract]
        double Multiplizieren(double zahl1, double zahl2);

        [OperationContract]
        [FaultContract(typeof(MathFault))]
        double Dividieren(int zahl1, int zahl2);

        [OperationContract]
        double Wurzelziehen(double zahl1, double zahl2);
    }
}
