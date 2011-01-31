using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.CommunicationAPI;
using System.ServiceModel;
using System.Runtime.Serialization;


namespace ConsoleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(PMACommunicationAPI)))
            {
                host.Open();
                Console.WriteLine("Press <enter> to terminate  the Application");
                Console.ReadKey(true);
            } 
        }
    }
}
