using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloServiceLibrary
{
    public class HelloService : IHelloService
    {
        public string SayHello(string name)
        {
            return "Hello, " + name + "!";
        }

    }
}
