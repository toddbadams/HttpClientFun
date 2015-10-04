using System;
using Microsoft.Owin.Hosting;

namespace WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting web Server...");
            IDisposable server = WebApp.Start<Startup>("http://localhost:9001/");
            Console.WriteLine("Server running at {0} - press Enter to quit. ", "http://localhost:9001/");
            Console.ReadLine();
        }

    }
}
