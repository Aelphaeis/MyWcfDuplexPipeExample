using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyWcfDuplexExample.Client
{
    class Program
    {
        static Timer timer = new Timer() { Interval = 5000, AutoReset = true, Enabled = true };
        static void Main(string[] args)
        {
            timer.Elapsed += timer_Elapsed;
            Console.WriteLine("Press Enter To Exit");
            Console.ReadLine();
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (MyServiceClient service = new MyServiceClient(new ICallback()))
                service.DoWork();
        }
    }
}
