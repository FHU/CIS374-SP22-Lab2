using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();

            heap1.Add(82);
            heap1.Add(95);
            heap1.Add(60);
            heap1.Add(51);
            heap1.Add(41);
            heap1.Add(39);
            heap1.Add(98);

            Console.WriteLine(heap1);
        }
    }
}

