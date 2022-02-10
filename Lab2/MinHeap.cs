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
		/// Time complexity: O(?).
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
		/// Time complexity: O(?).
		/// </summary>
		public T ExtractMax()
		{
			return default;
		}

		// TODO
		/// <summary>
		/// Removes and returns the min item in the min-heap.
		/// Time complexity: O(?).
		/// </summary>
		public T ExtractMin()
		{
			return default;
		}

		// TODO
		/// <summary>
		/// Returns true if the heap contains the given value; otherwise false.
		/// Time complexity: O(N).
		/// </summary>
		public bool Contains(T value)
		{
			// do a linear search of the array


			return false;
		}

		// TODO
		private void TrickleUp(int index)
		{

		}

		// TODO
		private void TrickleDown(int index)
		{

		}

		// TODO
		/// <summary>
		/// Gives the position of a node's parent, the node's position in the heap.
		/// </summary>
		private static int Parent(int position)
		{
			return 0;
		}

		// TODO
		/// <summary>
		/// Returns the position of a node's left child, given the node's position.
		/// </summary>
		private static int LeftChild(int position)
		{
			return 0;
		}

		// TODO
		/// <summary>
		/// Returns the position of a node's right child, given the node's position.
		/// </summary>
		private static int RightChild(int position)
		{
			return 0;
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

