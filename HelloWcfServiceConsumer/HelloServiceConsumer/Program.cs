using System;
using System.ServiceModel;

namespace HelloServiceConsumer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("http://localhost:8000/SEP");

            try
            {
                var client = new HelloServiceClient(binding, endpoint);

                while (true)
                {
                    Console.Clear();
                    ShowHelp();

                    var name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        break;
                    }

                    var ret = client.SayHello(name);

                    Console.WriteLine(ret);
                    Console.WriteLine("Hit <ENTER> to continue");
                    Console.ReadLine();
                }

                Console.ReadLine();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ShowHelp()
        {
            Console.Write("Input your name:");
        }
    }
}
