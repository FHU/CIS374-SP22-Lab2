using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();

            //heap1.Add(4);
            //heap1.Add(3);
            //heap1.Add(2);
            //heap1.Add(1);
            //heap1.Add(0);
            //Console.WriteLine(heap1.Count);

            int[] array = new int[3];

            array[0] = 1;
            array[1] = 3;
            array[2] = 2;

            Console.WriteLine(array[0].CompareTo(array[1]));
            Console.WriteLine(array[0].CompareTo(array[0]));
            Console.WriteLine(array[1].CompareTo(array[2]));
        }
    }
}

