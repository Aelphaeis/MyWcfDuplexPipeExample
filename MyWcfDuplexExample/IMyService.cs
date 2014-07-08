using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace MyWcfDuplexExample
{
    [ServiceContract(CallbackContract = typeof(IMyServiceCallback),SessionMode = SessionMode.Required)]
    public interface IMyService
    {
        [OperationContract(IsOneWay=true)]
        void DoWork();
    }
}
