using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWcfDuplexExample.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using(MyServiceServer server = new MyServiceServer())
            {
                server.Open();
                Console.WriteLine("Press Enter To Exit");
                Console.ReadLine();
                server.Close();
            }
        }
    }
}
