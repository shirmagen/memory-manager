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


            AsyncTest.Run();
            FragmentationTest.Run();
            MemoryOverflowTest.Run();
           
        }
    }
}
