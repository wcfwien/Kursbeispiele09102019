using System;
using System.ServiceModel;

namespace Taschenrechner
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, 
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class RechnerService : IRechnerService
    {
        public double Addieren(Rechner rechner)
        {
            return rechner.zahl1 + rechner.zahl2;
        }

        public double Dividieren(int zahl1, int zahl2)
        {
            try
            {
                return zahl1 / zahl2;
            }
            catch (DivideByZeroException)
            {
                var mf = new MathFault();
                mf.Operation = "Division";
                mf.ProblemType = "Division durch 0";

                throw new FaultException<MathFault>(mf, new FaultReason($"{mf.Operation} - {mf.ProblemType}"));
            }
        }

        public double Multiplizieren(double zahl1, double zahl2)
        {
            return zahl1 * zahl2;
        }

        public double Subtrahieren(double zahl1, double zahl2)
        {
            return zahl1 - zahl2;
        }

        public double Wurzelziehen(double zahl1, double zahl2)
        {
            throw new NotImplementedException();
        }
    }
}
