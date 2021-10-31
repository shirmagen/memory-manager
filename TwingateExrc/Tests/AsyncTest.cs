using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace TwingateExrc.Tests
{
    public static class AsyncTest
    {
        public static void Run()
        {
            Console.WriteLine("Async tests start:");
            var m = new MemoryManager(3);

            Task.WhenAll(Task.Run(() => {
                Thread.Sleep(1000);
                m.Allocate('2', 2);
            }),
            Task.Run(() => {
                Thread.Sleep(100);
                m.Allocate(new[] { '1', '1' }, 0);
            })).Wait();

            m.Free(0);

            if (m.Buffer[0] == default(char) && m.Buffer[1] == '1' && m.Buffer[2] == '2')
            {
                Console.WriteLine("     First test passed");
            }
            else
            {
                Console.WriteLine("     First test failed");
            }

            var m2 = new MemoryManager(3);

            Task.WhenAll(Task.Run(() => {
                //Thread.Sleep(100);
                m2.Allocate('2', 0);
            }),
           Task.Run(() => {
               Thread.Sleep(1000);
               m2.Allocate(new[] { '1', '1' }, 1);
           })).Wait();

            m2.Free(0);

            if (m2.Buffer[0] == default(char) && m2.Buffer[1] == '1' && m2.Buffer[2] == '1')
            {
                Console.WriteLine("     Second test passed");
            }
            else
            {
                Console.WriteLine("     Second test failed");
            }
        }
    }
}
