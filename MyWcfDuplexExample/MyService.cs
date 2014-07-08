using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace MyWcfDuplexExample
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MyService : IMyService
    {
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
