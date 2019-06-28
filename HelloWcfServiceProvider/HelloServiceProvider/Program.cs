using System;
using System.ServiceModel;
using System.ServiceModel.Description;

using HelloServiceLibrary;

namespace HelloServiceProvider
{
    static class Program
    {
        static void Main(string[] args)
        {
            var baseAddr = new Uri("http://localhost:8000/");

            var serviceHost = new ServiceHost(typeof(HelloService), baseAddr);

            try
            {
                serviceHost.AddServiceEndpoint(typeof(IHelloService), new BasicHttpBinding(), "SEP");

                var behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                serviceHost.Description.Behaviors.Add(behavior);

                serviceHost.Open();

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();

                serviceHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                serviceHost.Abort();
            }
        }
    }
}
