using System;
using System.Collections.Generic;
using TwingateExrc.Exceptions;

namespace TwingateExrc.Tests
{
    public static class MemoryOverflowTest
    {
        public static void Run()
        {
            Console.WriteLine("Memory overflow tests start:");
            var memory = new LinkedList<char>();
            var m = new MemoryManager<char>(memory, 6);

            m.Allocate('3', 1);
            m.Allocate(new[] {'1', '1' }, 2); ;
            m.Allocate('4', 1);
            try
            {
                m.Allocate('5', 1);
            }
            catch (MemoryOverflowException)
            {
                Console.WriteLine("     Test passed");
            }
            catch (Exception)
            {
                Console.WriteLine("     Test Failed");
            }
           
            
        }
    }
}
