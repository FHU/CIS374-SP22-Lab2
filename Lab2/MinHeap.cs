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

		public MinHeap(T[] initialArray=null)
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

		// TODO
		/// <summary>
		/// Adds given item to the heap.
		/// Time complexity: O(logn).
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

		// TODO
		/// <summary>
		/// Removes and returns the max item in the min-heap.
		/// Time complexity: O(1).
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
				if (array[i].CompareTo(max) < 0)
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

		// TODO
		/// <summary>
		/// Removes and returns the min item in the min-heap.
		/// Time complexity: O(n).
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

		// TODO
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
			if (array[index].CompareTo(array[Parent(index)]) < 0)
			{
				Swap(index, Parent(index));
				TrickleUp(Parent(index));
			}

		}

		// TODO
		private void TrickleDown(int index)
		{
			if(LeftChild(index) == Count && array[index].CompareTo(array[LeftChild(index)]) > 0){
				Swap(index, LeftChild(index));
				return;
            }
			if(RightChild(index) == Count && array[index].CompareTo(array[RightChild(index)]) > 0)
            {
				Swap(index, RightChild(index));
				return;
            }
			if(LeftChild(index)>= Count || RightChild(index)>=Count)
				return;
            if (array[LeftChild(index)].CompareTo(array[RightChild(index)])<0 && array[index].CompareTo(array[LeftChild(index)])>0)
            {
				Swap(index, LeftChild(index));
				TrickleDown(LeftChild(index));
            }
			else if (array[index].CompareTo(array[RightChild(index)])>0)
            {
				Swap(index, RightChild(index));
				TrickleDown(RightChild(index));
            }
		}

		// TODO
		/// <summary>
		/// Gives the position of a node's parent, the node's position in the heap.
		/// </summary>
		private static int Parent(int position)
		{
			return (position - 1) / 2;
		}

		// TODO
		/// <summary>
		/// Returns the position of a node's left child, given the node's position.
		/// </summary>
		private static int LeftChild(int position)
		{
			return (position * 2) + 1;
		}

		// TODO
		/// <summary>
		/// Returns the position of a node's right child, given the node's position.
		/// </summary>
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

