using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwingateExrc.Exceptions
{
    public class NotEnoughAvailableMemoryException : Exception
    {
        public NotEnoughAvailableMemoryException(string message) : base(message)
        {
        }
    }
}
