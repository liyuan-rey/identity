using System;
using IdentityNS.Server.Core;
using Microsoft.Owin.Hosting;

namespace IdentityNS.Server.SelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "identity - Server:SelfHost";

            const string url = "http://localhost:12345";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server listening at {0} ...", url);
                Console.WriteLine("Press enter to stop.");
                Console.ReadLine();
            }
        }
    }
}