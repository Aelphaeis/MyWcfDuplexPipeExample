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
        [OperationContract(IsOneWay = true)]
        void WorkComplete();
    }
}
