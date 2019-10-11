using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace Ta.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // SOAP Host
                using (ServiceHost host = new ServiceHost(typeof(TravelService)))
                {
                    host.Open();

                    // Find in CMD: netstat -ona | find "8733"
                    Console.WriteLine("Taste drücken, zum Beenden...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
