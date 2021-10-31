using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TwingateExrc.Tests;

namespace TwingateExrc
{
    class Program
    {
        static void Main(string[] args)
        {
            var memory = new LinkedList<char>();
            var m = new MemoryManager<char>(memory, 5);


            AsyncTest.Run();

            //m.Allocate('3', 1);
            //m.Allocate(new[] {'1', '1' }, 2); ;
            // m.Allocate('4', 1);
            //m.Allocate('5', 1);
            //m.Free();
            //m.Free();
            //m.Allocate('2',1);
            //m.Allocate('4',1);

           // var current = m.Buffer.First;
           // while(current != null)
           // {
           //     Console.WriteLine(current.Value);
             //   current = current.Next;
            //}
           
        }
    }
}
