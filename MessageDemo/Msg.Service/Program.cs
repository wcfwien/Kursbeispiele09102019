using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;
using static System.ServiceModel.OperationContext;

namespace Msg.Service
{
    [ServiceContract]
    public interface IMessageService 
    {
        [OperationContract]
        void Mahlzeit(String input);

        //[OperationContract]
        //Task MahlzeitEtwasAsync(String input);
    }

    public class MessageService : IMessageService
    {
        public void Mahlzeit(string input)
        {
            Console.WriteLine(input);
            Console.WriteLine(Current.RequestContext.RequestMessage.ToString());
        }

        public async Task MahlzeitEtwasAsync(string input)
        {
            await Task.Factory.StartNew(() => 
            {
                Console.WriteLine("Schnitzl in die Pfanne");

                Thread.Sleep(2000);

                Console.WriteLine($"Leider ist {input} zu lange in der PFanne gewesen...");
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Adresse
            var address = new Uri("http://localhost:1234/MessageService");
            // Binding
            var binding = new BasicHttpBinding();
            // ServiceHost
            var svc = new ServiceHost(typeof(MessageService));
            // Endpoint
            ServiceEndpoint ep = svc.AddServiceEndpoint(typeof(IMessageService), binding, address);

            // Metadata
            var metadata = new ServiceMetadataBehavior();
            svc.Description.Behaviors.Add(metadata);
            // Metadata Binding
            var mexBinding = MetadataExchangeBindings.CreateMexTcpBinding();
            // Metadata Adresse ws-metadata exchange traffic
            var mexAddress = new Uri("net.tcp://localhost:5000/IMessageService/Mex");
            // Endpoint Metadata
            svc.AddServiceEndpoint(typeof(IMessageService), mexBinding, mexAddress);

            svc.Open();
            var factory = new ChannelFactory<IMessageService>(binding, new EndpointAddress(address));
            var proxy = factory.CreateChannel();
            proxy.Mahlzeit("Schnitzel");

            Console.ReadLine();
            svc.Close();
        }
    }
}
