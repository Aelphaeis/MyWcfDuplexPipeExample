using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace MyWcfDuplexExample
{
    public class MyServiceServer : IDisposable
    {
        public Boolean IsDisposed { get; private set; }
        ServiceHost host { get; set; }


        public void Open()
        {
            if (host != null)
                Dispose();

            IsDisposed = false;
            host = new ServiceHost(typeof(MyService), new Uri(Constants.myPipeService));
            host.AddServiceEndpoint(typeof(IMyService), new NetNamedPipeBinding(), Constants.myPipeServiceName);

            host.BeginOpen(OnOpen, host);
        }

        public void Close()
        {
            host.BeginClose(OnClose, host);
        }

        public void Dispose()
        {
            ((IDisposable)host).Dispose();
            IsDisposed = true;
            host = null;
        }

        void OnOpen(IAsyncResult ar)
        {
            ServiceHost service = (ServiceHost)ar.AsyncState;
            service.EndOpen(ar);
        }
        void OnClose(IAsyncResult ar)
        {
            ServiceHost service = (ServiceHost)ar.AsyncState;
            service.EndClose(ar);
            Dispose();
        }
    }
}
