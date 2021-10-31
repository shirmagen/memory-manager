using System;

namespace TwingateExrc.Exceptions
{
    public class MemoryOverflowException : Exception
    {
        public MemoryOverflowException()
        {
        }

        public MemoryOverflowException(string message) : base(message)
        {
        }

        public MemoryOverflowException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
