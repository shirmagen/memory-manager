using System;
using System.Collections.Generic;
using TwingateExrc.Exceptions;

namespace TwingateExrc
{
    public class MemoryManager<T> 
    {
        public LinkedList<T> Buffer { get; set; } = new LinkedList<T>();
        public int MaxSize { get; set; }
        public LinkedList<int> AllocationHistory { get; set; } = new LinkedList<int>();
        public MemoryManager(LinkedList<T> buffer, int size)
        {
            EnsureBuffer(buffer, size);
            Buffer = buffer;
            MaxSize = size;
            AllocationHistory.AddLast(size);
        }

        private void EnsureBuffer(LinkedList<T> buffer, int maxSize)
        {
            if (buffer.Count > maxSize)
            {
                throw new Exception("Buffer data is larger than maximum size avialable");
            }
        }

        public void Allocate(T[] items, int size)
        {
            lock (Buffer)
            {
                lock (AllocationHistory)
                {

                    BeforeAllocation(size);

                    foreach (var item in items)
                    {
                        Buffer.AddLast(item);
                    }


                    AllocationHistory.AddLast(size);
                }
            }
        }

        public void Allocate(T item, int size = 1)
        {
            lock (Buffer)
            {
                lock (AllocationHistory)
                {
                    BeforeAllocation(size);
                    Buffer.AddLast(item);

                    AllocationHistory.AddLast(size);
                }
            }
        }

        private void BeforeAllocation(int size)
        {
            EnsureAllocation(size);
        }

        private void EnsureAllocation(int size)
        {
            if(Buffer.Count + size > MaxSize)
            {
                throw new MemoryOverflowException("Not enough memory for this allocation");
            }
        }

        public void Free()
        {
            lock (AllocationHistory)
            {
                lock(Buffer)
                {
                    for (int i = 0; i < AllocationHistory.Last.Value; i++)
                    {
                        Buffer.RemoveLast();
                    }

                    AllocationHistory.RemoveLast();
                }
            }
           
        }
    }
}
