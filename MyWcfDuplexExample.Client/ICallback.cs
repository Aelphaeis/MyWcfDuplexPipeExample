using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWcfDuplexExample.Client
{
    class ICallback : IMyServiceCallback
    {
        public void WorkComplete()
        {
            Console.WriteLine("Work Complete");
        }
    }
}
