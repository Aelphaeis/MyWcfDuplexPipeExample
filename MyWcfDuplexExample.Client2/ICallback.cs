using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWcfDuplexExample.Client2
{
    class Callback : IMyServiceCallback
    {
        public int ClientId { get; set; }

        public int GetClientId()
        {
            return ClientId;
        }

        public void WorkComplete()
        {
            Console.WriteLine("Work Complete for Client 2");
        }

        public void RecieveMessage(string msg)
        {
            Console.WriteLine("Message Recieved: {0}", msg);
        }
    }
}
