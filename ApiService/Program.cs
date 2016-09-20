using Nancy.Hosting.Self;
using System;

namespace ApiService
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri =
                new Uri("http://localhost:8085");

            using (var host = new NancyHost(uri))
            {
                host.Start();

                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
                Console.WriteLine("Bye bye.");
            }
        }
    }
}
