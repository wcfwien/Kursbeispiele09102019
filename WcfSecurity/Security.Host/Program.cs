using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Security.Host
{
    [ServiceContract]
    public interface IDemoService 
    {
        [OperationContract]
        int Addition(int x, int y);
    }

    public class DemoService : IDemoService
    {
        public int Addition(int x, int y)
        {
            return x + y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // HOST Server /////////////////////
            // Adresse
            Uri httpUrl = new Uri("http://localhost:3333/DemoService");

            // Host mit Contract und Url, Binding separat
            ServiceHost host = new ServiceHost(typeof(DemoService), httpUrl);

            // Binding + Behaviors
            BasicHttpBinding http = new BasicHttpBinding();
            // 1 Set TransportCredentialOnly != https
            http.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            // 2 Basic Transport Security => UserId und PW
            http.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            host.AddServiceEndpoint(typeof(IDemoService), http, "");
            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode =
                UserNamePasswordValidationMode.Custom;
            host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator =
                new DemoValidator();

            // Start
            host.Open();
            Console.WriteLine($"Der Service läuft unter dem folgenden Account: {WindowsIdentity.GetCurrent().Name}");

            Console.WriteLine(DateTime.Now.ToString() + " Service gehostet auf: " + httpUrl.ToString());
            Console.WriteLine("Taste drücken, um Service zu beenden...");
                        
            Console.ReadLine();
        }

        public class DemoValidator : UserNamePasswordValidator 
        {
            public override void Validate(string userName, string password)
            {
                if ((userName != "rapid" || (password != "wien123")))
                {
                    throw new ExpiredSecurityTokenException("Leider kein Zugriff! Austrianer?");
                }
                Console.WriteLine(DateTime.Now.ToString() + "Validation Succss für Benutzer"
                    + userName);
            }
        }
    }
}
