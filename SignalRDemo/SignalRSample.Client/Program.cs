using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SignalRSample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hub Verbindung wird aufgebaut...");

            var url = "http://localhost:63825/chatHub";

            var hubConnection = new HubConnectionBuilder()
                .WithUrl(url).Build();

            hubConnection.On<string>("EmpfangeNachricht", msg => EmpfangeNachricht(msg));

            hubConnection.StartAsync().Wait();

            var running = true;

            while (running)
            {
                Console.WriteLine("Bitte Nachricht eingeben...");
                var message = string.Empty;

                message = Console.ReadLine();

                hubConnection.SendAsync("SendMessage", message).Wait();
            }
        }

        private static void EmpfangeNachricht(string msg)
        {
            Console.WriteLine($"SignalR Hub Nachricht: {msg}");
        }
    }
}
