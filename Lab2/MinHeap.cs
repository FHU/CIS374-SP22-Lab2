using System;
using System.Linq;

namespace Lab2
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] array;
        private int initialSize = 8;

        public int Count { get; private set; } = 0;

        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;

        public MinHeap(T[] initialArray = null)
        {
            array = new T[initialSize];

            // Add initial value if present
            if (initialArray != null && initialArray.Length > 0)
            {
                foreach (var item in initialArray)
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Returns the min item but does NOT remove it.
        /// Time complexity: O(1).
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            return array[0];
        }

        /// <summary>
        /// Adds given item to the heap.
        /// Time complexity: O(logN).
        /// </summary>
        public void Add(T item)
        {
            int nextEmptyIndex = Count;

            array[nextEmptyIndex] = item;

            TrickleUp(Count);

            Count++;

            // Resize array if full
            if (Count == array.Length)
            {
                DoubleArrayCapacity();
            }
        }

        public T Extract()
        {
            return ExtractMin();
        }

        /// <summary>
        /// Removes and returns the max item in the min-heap.
        /// Time complexity: O(NlogN).
        /// </summary>
        public T ExtractMax()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            int maxIndex = (Count - 1) / 2 + 1;
            T max = array[maxIndex];
            for (int i = maxIndex + 1; i < Count; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                    maxIndex = i;
                }
            }

            // remove min
            // swap min with last element
            Swap(maxIndex, Count - 1);

            // remove last element
            Count--;

            TrickleUp(maxIndex);

            return max;
        }

        /// <summary>
        /// Removes and returns the min item in the min-heap.
        /// Time complexity: O(logN).
        /// </summary>
        public T ExtractMin()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T min = array[0];

            // swap max with last element
            Swap(0, Count - 1);

            // remove last element
            Count--;

            // trickle down from root
            TrickleDown(0);

            return min;
        }

        /// <summary>
        /// Returns true if the heap contains the given value; otherwise false.
        /// Time complexity: O(N).
        /// </summary>
        public bool Contains(T value)
        {
            // do a linear search of the array
            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void TrickleUp(int index)
        {
            while (index > 0)
            {
                var parentIndex = Parent(index);
                if (array[index].CompareTo(array[parentIndex]) >= 0)
                {
                    return;
                }
                else
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
            }
        }

        private void TrickleDown(int index)
        {
            var childIndex = LeftChild(index);
            var value = array[index];

            while (childIndex < Count)
            {
                var minValue = value;
                var minIndex = -1;

                for (int i = 0; i < 2 && i + childIndex < Count; i++)
                {
                    if (array[i + childIndex].CompareTo(minValue) < 0)
                    {
                        minValue = array[i + childIndex];
                        minIndex = i + childIndex;
                    }
                }

                if (minValue.CompareTo(value) == 0)
                {
                    return;
                }
                else
                {
                    Swap(index, minIndex);
                    index = minIndex;
                    childIndex = LeftChild(index);
                }
            }
        }

        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {
            if (position > 0)
            {
                return (position - 1) / 2;
            }

            return 0;
        }

        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
            return 2 * position + 1;
        }

        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
            return 2 * (position + 1);
        }

        private void Swap(int index1, int index2)
        {
            var temp = array[index1];

            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void DoubleArrayCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }

        public override string ToString()
        {
            var result = "[";

            for (int i = 0; i < Count - 1; i++)
            {
                result += array[i] + ", ";
            }

            result += array[Count - 1] + "]";

            return result;
        }
    }
}

