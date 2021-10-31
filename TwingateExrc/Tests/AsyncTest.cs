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
            var memory = new LinkedList<char>();
            var m = new MemoryManager<char>(memory, 3);

            Task.WhenAll(Task.Run(() => {
                Thread.Sleep(1000);
                m.Allocate('2', 1);
            }),
            Task.Run(() => {
                Thread.Sleep(100);
                m.Allocate(new[] { '1', '1' }, 2);
            })).Wait();

            m.Free();

            if (m.Buffer.Last.Value == '1')
            {
                Console.WriteLine("     First test passed");
            }
            else
            {
                Console.WriteLine("     First test failed");
            }

            var memory2 = new LinkedList<char>();
            var m2 = new MemoryManager<char>(memory2, 3);

            Task.WhenAll(Task.Run(() => {
                Thread.Sleep(100);
                m2.Allocate('2', 1);
            }),
           Task.Run(() => {
               Thread.Sleep(1000);
               m2.Allocate(new[] { '1', '1' }, 2);
           })).Wait();

            m2.Free();

            if (m2.Buffer.Last.Value == '2')
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
