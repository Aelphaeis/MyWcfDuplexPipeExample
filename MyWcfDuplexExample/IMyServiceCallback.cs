using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MyWcfDuplexExample
{
    [ServiceContract]
    public interface IMyServiceCallback 
    {
        [OperationContract]
        int GetClientId();

        [OperationContract(IsOneWay = true)]
        void WorkComplete();

        [OperationContract(IsOneWay = true)]
        void RecieveMessage(String msg);
    }
}
