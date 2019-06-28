using System;
using System.ServiceModel;

namespace HelloServiceLibrary
{
    [ServiceContract(Namespace = "HelloWcf.Example")]
    public interface IHelloService
    {
        [OperationContract]
        string SayHello(string name);
    }
}
