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
            var m = new MemoryManager(4);

            m.Allocate('3', 0);
            m.Allocate(new[] {'1', '1' }, 1); ;
            m.Allocate('4', 3);
            try
            {
                m.Allocate('5', 4);
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
