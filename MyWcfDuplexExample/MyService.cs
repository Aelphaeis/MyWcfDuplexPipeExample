using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace MyWcfDuplexExample
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyService : IMyService
    {
        public List<IMyServiceCallback> Callbacks { get; private set; }

        public MyService(){
            Callbacks = new List<IMyServiceCallback>();
        }

        public void Init()
        {
            Callbacks.Add(Callback);
        }

        public void DoWork()
        {
            Console.WriteLine("Hello World");
            Callback.WorkComplete();
        }


        IMyServiceCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IMyServiceCallback>();
            }
        }
    }
}
