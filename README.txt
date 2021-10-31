The implementation for this memory manager was meant to be a simple as it can be.
The idea is to keep pointers from each page in the buffer to the next one the memory should allocate after him and solve fragmentation issue.
I chose to work with .NET Framework as it is cery efficient and convinient in managing object oriented projects and maintaining threads.
PagesPointers keep track of the allocation order
Allocate function allocates in buffer and removes busy pages from allocation order
Free function frees pages in buffer as well as adding them back to the allocation order