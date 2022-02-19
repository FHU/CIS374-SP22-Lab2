using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();
            heap1.Add(2);
            heap1.Add(4);
            
            heap1.Add(3);
            heap1.Add(1);
            heap1.Add(0);

            heap1.ExtractMax();
            heap1.ExtractMax();
            heap1.ExtractMax();
            Console.WriteLine(heap1.ExtractMax());

        }
    }
}

