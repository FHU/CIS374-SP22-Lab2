using System;
using System.Linq;

namespace Lab2
{
	public class MaxHeap<T> where T: IComparable<T>
	{
		private T[] array;
		private int initialSize = 8;

		public int Count { get; private set; } = 0;

		public int Capacity => array.Length;

		public bool IsEmpty => Count == 0;

		public MaxHeap(T[] initialArray = null)
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
		/// Time complexity: O(1).
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
			return ExtractMax();
        }

		// TODO
		/// <summary>
		/// Removes and returns the max item in the max-heap.
		/// Time complexity: O(1).
		/// </summary>
		public T ExtractMax()
        {
			if (IsEmpty)
			{
				throw new Exception("Empty Heap");
			}

			T max = array[0];

			// swap max with last element
			Swap(0, Count - 1);

			// remove last element
			Count--;

			// trickle down from root
			TrickleDown(0);

			return max;
        }

		/// <summary>
		/// Removes and returns the min item in the max-heap.
		/// Time complexity: O(n).
		/// </summary>
		public T ExtractMin()
        {
			if(IsEmpty)
            {
				throw new Exception("Empty Heap");
            }

			int minIndex = (Count-1)/2 + 1;
			T min = array[minIndex];
			for (int i = minIndex + 1; i < Count; i++)
            {
				if (array[i].CompareTo(min) < 0)
                {
					min = array[i];
					minIndex = i;
                }
            }

			// remove min
			// swap min with last element
			Swap(minIndex, Count - 1);

			// remove last element
			Count--;

			TrickleUp(minIndex);

			return min;
		}

		/// <summary>
		/// Returns true if the heap contains the given value; otherwise false.
		/// Time complexity: O(N).
		/// </summary>
		public bool Contains(T value)
		{
			// do a linear search of the array
			for (int i = 0; i <= Count; i++)
			{
				if (array[i].Equals(value))
					return true;
            }
			return false;
		}

		// TODO
		private void TrickleUp(int index)
		{
			if (index == 0)
			{
				return;
			}
			if (array[index].CompareTo(array[Parent(index)]) > 0)
			{
				Swap(index, Parent(index));
				TrickleUp(Parent(index));
			}

		}

		// TODO
		private void TrickleDown(int index)
		{
			if (LeftChild(index) == Count && array[index].CompareTo(array[LeftChild(index)]) < 0)
			{
				Swap(index, LeftChild(index));
				return;
			}
			if (RightChild(index) == Count && array[index].CompareTo(array[RightChild(index)]) < 0)
			{
				Swap(index, RightChild(index));
				return;
			}
			if (LeftChild(index) >= Count || RightChild(index) >= Count)
				return;
			if (array[LeftChild(index)].CompareTo(array[RightChild(index)]) > 0 && array[index].CompareTo(array[LeftChild(index)]) < 0)
			{
				Swap(index, LeftChild(index));
				TrickleDown(LeftChild(index));
			}
			else if (array[index].CompareTo(array[RightChild(index)]) < 0)
			{
				Swap(index, RightChild(index));
				TrickleDown(RightChild(index));
			}
		}

		/// <summary>
		/// Gives the position of a node's parent, the node's position in the heap.
		/// </summary>
		// TODO
		private static int Parent(int position)
		{
			return (position - 1) / 2;
		}

		/// <summary>
		/// Returns the position of a node's left child, given the node's position.
		/// </summary>
		// TODO
		private static int LeftChild(int position)
		{
			return (position * 2) + 1;
		}

		/// <summary>
		/// Returns the position of a node's right child, given the node's position.
		/// </summary>
		// TODO
		private static int RightChild(int position)
		{
			return (position * 2) + 2;
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
	}
}

