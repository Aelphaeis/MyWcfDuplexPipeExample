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
                int i = -1;
                server.Open();
                Console.WriteLine("0 To Exit | Num > 0 to send message");

                do
                {
                    if (Int32.TryParse(Console.ReadLine(), out i))
                        if (i > 0)
                            server.Msg(i);

                } while (i != 0);
            }
        }
    }
}
