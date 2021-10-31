using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwingateExrc.Tests
{
    public static class FragmentationTest
    {
        public static void Run()
        {
            Console.WriteLine("Fragmentation tests start:");
            var m = new MemoryManager(5);

            m.Allocate('1', 0);
            m.Allocate('1', 1);
            m.Allocate('1', 2);

            m.Free(0);
            m.Free(2);
            m.Allocate(new[] { '2', '2' }, 0);

            if (m.Buffer[0] == '2' && m.Buffer[1] == '1' && m.Buffer[2] == '2')
            {
                Console.WriteLine("     passed");
            }
            else 
            {
                Console.WriteLine("failed");
            }


        }
    }
}
