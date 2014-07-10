using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace MyWcfDuplexExample.Client2
{
    class Program
    {
        static MyServiceClient service = new MyServiceClient(new Callback { ClientId = 2 });
        static Timer timer = new Timer() { Interval = 5000, AutoReset = true, Enabled = true };
        static void Main(string[] args)
        {
            using(service){
                timer.Elapsed += timer_Elapsed;
                Console.WriteLine("Press Enter To Exit");
                Console.ReadLine();
            }
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            service.DoWork();
        }
    }
}
