using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Autovermietung.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class AutoService : IAutoService
    {
        public static void Main(string[] args) 
        {
            try
            {
                WebServiceHost host = new WebServiceHost(typeof(AutoService));
                host.Open();
                Console.WriteLine("Hit any key to exit...");
                Console.ReadKey();
                host.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public List<Auto> GetAllAutos()
        {
            return new List<Auto>() 
            { 
                new Auto()
                { 
                    Id = 1,
                    Hersteller = "BMW",
                    ModelName = "Z3"
                },
                new Auto()
                {
                    Id = 2,
                    Hersteller = "Fiat",
                    ModelName = "Punto"
                }
            };
        }
    }
}