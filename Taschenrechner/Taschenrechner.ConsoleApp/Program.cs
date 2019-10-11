using System;
using System.ServiceModel;

namespace Taschenrechner.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(RechnerService)))
            {
                host.Open();

                Console.ReadKey();
            }
        }
    }
}
