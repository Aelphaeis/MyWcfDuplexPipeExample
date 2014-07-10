using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
namespace MyWcfDuplexExample
{
    public class MyServiceClient: IMyService, IDisposable
    {
        DuplexChannelFactory<IMyService> myServiceFactory { get; set; }

        public MyServiceClient(IMyServiceCallback Callback)
        {
            InstanceContext site = new InstanceContext(Callback);
            NetNamedPipeBinding binding = new NetNamedPipeBinding();
            EndpointAddress endpointAddress = new EndpointAddress(Constants.myPipeService + @"/" + Constants.myPipeServiceName);

            myServiceFactory = new DuplexChannelFactory<IMyService>(site, binding, endpointAddress);
            Init();
        }
        public void Init()
        {
            myServiceFactory.CreateChannel().Init();
        }

        public void DoWork()
        {
            myServiceFactory.CreateChannel().DoWork();
        }

        public void Dispose()
        {
            myServiceFactory.Close();
        }
    }
}
