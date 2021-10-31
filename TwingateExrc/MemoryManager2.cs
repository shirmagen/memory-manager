using System;
using System.Collections.Generic;
using System.Linq;
using TwingateExrc.Exceptions;

namespace TwingateExrc
{
    public class MemoryManager2
    {
        public LinkedList<int> PagesPointers { get; set; } = new LinkedList<int>();
        public int MaxSize { get; set; }
        public char[] Buffer { get; set; }
        public bool[] isFreePage { get; set; }
        public MemoryManager2(int size)
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
                throw new Exception("not enough memory");
            }

            int? newPage = page;

            lock (Buffer)
            {
                lock (PagesPointers)
                {

                    foreach (var item in items)
                    {
                        if (newPage == null)
                        {
                            throw new Exception();
                        }

                        EnsureAllocation(newPage.Value);
                        Buffer[newPage.Value] = item;
                        if (PagesPointers.Find(newPage.Value).Next != null)
                        {
                            newPage = PagesPointers.Find(newPage.Value).Next.Value;
                        }
                        else
                        {
                            newPage = null;
                        }
                       
                    }

                }
            }
        }

        public void Allocate(char item, int page)
        {
            EnsureAllocation(page);
            
            lock (Buffer)
            {
                lock (PagesPointers)
                {
                    EnsureAllocation(page);
                    Buffer[page] = item;
                    PagesPointers.Remove(page);
                  //  var current = PagesPointers.First;
                  //  while (current != null)
                  //  {
                  //      if(current.Next.Value != page)
                  //      {
                  //          current = current.Next;
                  //      }
                  //      else
                  //      {
                  //          break;
                  //      }
                  //  }
                  //
                  //  if(current == null)
                  //  {
                  //      throw new Exception();
                  //  }
                  //
                  //  current.Next = PagesPointers.Find(page).Next;
                }
            }
        }
        private void EnsureAllocation(int page)
        {
            if (Buffer[page] != default(char))
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
