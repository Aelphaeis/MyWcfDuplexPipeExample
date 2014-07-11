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
        Boolean disposed;
        ServiceHost host { get; set; }
        MyService service;

        public MyServiceServer()
        {
            disposed = false;
            service = new MyService();
            host = new ServiceHost(service, new Uri(Constants.myPipeService));
            host.AddServiceEndpoint(typeof(IMyService), new NetNamedPipeBinding(), Constants.myPipeServiceName);
        }
        public void Open()
        {
            host.BeginOpen(OnOpen, host);
        }

        public void Msg(int ClientId)
        {
            foreach (var cb in service.Callbacks)
                if (cb.GetClientId() == ClientId)
                    cb.RecieveMessage("We have called you choosen one");
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (disposed)
                return;
            if(disposing)
                host.Close();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        ~MyServiceServer()
        {
            Dispose(false);
        }
    }
}
