using System;
using System.ServiceModel;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Service)))
            {
                host.Open();
                Console.WriteLine("Server is on\nPress any key to stop");
                Console.ReadLine();
            }
        }
    }
}
