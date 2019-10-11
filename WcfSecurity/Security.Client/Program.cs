using Security.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Security.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Client Channel Factory
            EndpointAddress serviceAddress = new EndpointAddress("http://localhost:3333/DemoService/");

            // Binding
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            httpBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            ChannelFactory<IDemoService> myChannelFacotry = 
                new ChannelFactory<IDemoService>(httpBinding, serviceAddress);

            myChannelFacotry.Credentials.UserName.UserName = "rapid";
            myChannelFacotry.Credentials.UserName.Password = "wien123";

            // Proxy Erstellung
            IDemoService proxy = myChannelFacotry.CreateChannel();

            var ergebnis = proxy.Addition(2,3);
            Console.WriteLine($"Ergebnis: {ergebnis.ToString()}");
                                   
            ((IClientChannel)proxy).Close();

            Console.ReadKey();
        }
    }
}
