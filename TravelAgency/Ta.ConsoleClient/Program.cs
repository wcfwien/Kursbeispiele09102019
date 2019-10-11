using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ta.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                // GET
                var response = client
                    .GetAsync("http://localhost:1234/travelservice/sights")
                    .Result;

                HttpContent stream = response.Content;
                var data = stream.ReadAsStringAsync();

                Console.WriteLine(data.Result);
            }
            
            Console.ReadKey();
        }
    }
}
