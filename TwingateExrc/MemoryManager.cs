using System;
using System.Collections.Generic;
using System.Linq;
using TwingateExrc.Exceptions;

namespace TwingateExrc
{
    public class MemoryManager
    {
        public LinkedList<int> PagesPointers { get; set; } = new LinkedList<int>();
        public char[] Buffer { get; set; }

        public MemoryManager(int size)
        {
            Buffer = new char[size];
            SetBuffer(size);
        }

        private void SetBuffer(int size)
        {
            for (int i = 0; i < size; i++)
            {
                PagesPointers.AddLast(i);
            }
        }

        public void Allocate(char[] items, int page)
        {
            if(items.Length > Buffer.Length || Buffer.Count(x => x == default(char)) < items.Length)
            {
                throw new NotEnoughAvailableMemoryException("not enough memory for this data");
            }

            int? newPage = page;
            int? oldPage = null;

            lock (Buffer)
            {
                lock (PagesPointers)
                {

                    foreach (var item in items)
                    {
                        if (newPage == null)
                        {
                            throw new Exception("Internal Error - couldnwt allocate pages");
                        }

                        EnsureAllocation(newPage.Value);
                        Buffer[newPage.Value] = item;
                        
                        if (PagesPointers.Find(newPage.Value).Next != null)
                        {
                            oldPage = newPage.Value;
                            newPage = PagesPointers.Find(oldPage.Value).Next.Value;
                        }
                        else
                        {
                            newPage = null;
                        }

                        PagesPointers.Remove(oldPage.Value);

                        

                    }

                }
            }
        }

        public void Allocate(char item, int page)
        {   
            lock (Buffer)
            {
                lock (PagesPointers)
                {
                    EnsureAllocation(page);
                    Buffer[page] = item;
                    PagesPointers.Remove(page);
                }
            }
        }
        private void EnsureAllocation(int page)
        {
            if (page > Buffer.Length - 1 || Buffer[page] != default(char))
            {
                throw new MemoryOverflowException("page not avialable for this allocation");
            }
        }

        public void Free(int page)
        {
            lock (PagesPointers)
            {
                lock (Buffer)
                {
                    Buffer[page] = default(char);
                    PagesPointers.AddLast(page);
                }
            }

        }
    }
}
