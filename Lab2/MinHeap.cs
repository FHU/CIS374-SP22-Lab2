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
			T max = array[Count - 1];
			Count--;

			return max;
		}

		// TODO
		/// <summary>
		/// Removes and returns the min item in the min-heap.
		/// Time complexity: O(?).
		/// </summary>
		public T ExtractMin()
		{
			if (IsEmpty)
			{
				throw new Exception("Empty Heap");
			}

			int minIndex = (Count - 1) / 2 + 1;
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
			//Swap(minIndex, Count - 1);
			array[0] = array[Count - 1];

			// remove last element
			Count--;

			TrickleUp(minIndex);

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

			//foreach (T item in array)
			//{
			//	if (item == value)
			//	{
			//		return true;
			//	}
			//}

			return false;
		}

		// TODO
		private void TrickleUp(int index)
		{

			while (index > 0)
			{
				// Compute the parent node's index
				int parentIndex = (index - 1) / 2;

				// Check for a violation of the max heap property
				if (Convert.ToInt32(array[index]) >= Convert.ToInt32(array[parentIndex]))
				{
					// No violation, so percolate up is done.
					return;
				}
				else
				{
					// Swap heapArray[nodeIndex] and heapArray[parentIndex]
					T temp = array[index];
					array[index] = array[parentIndex];
					array[parentIndex] = temp;

					// Continue the loop from the parent node
					index = parentIndex;
				}
			}
		}

		// TODO
		private void TrickleDown(int index)
		{
			int childIndex = 2 * index + 1;
			T value = array[index];

			while (index < array.Length)
			{
				// Find the max among the node and all the node's children
				T maxValue = value;

				int maxIndex = -1;
				//(int i = 0; i < 5; i++) 
				for (int i = 0; i < 2 && i + childIndex < array.Length; i++)
				{
					if (Convert.ToInt32(array[i + childIndex]) < Convert.ToInt32(maxValue))
					{
						maxValue = array[i + childIndex];


						maxIndex = i + childIndex;

					}
				}

				if (Convert.ToInt32(maxValue) == Convert.ToInt32(value))
				{
					return;

				}
				else
				{
					var temp = array[index];

					array[index] = array[maxIndex];
					array[maxIndex] = temp;
					//swap(Convert.ToInt32(array[index]), Convert.ToInt32(array[maxIndex]))

					index = maxIndex;


					childIndex = 2 * index + 1;

				}
			}
		}

			// TODO
			/// <summary>
			/// Gives the position of a node's parent, the node's position in the heap.
			/// </summary>
			private static int Parent(int position)
			{
				int pos = (position - 1) / 2;
				decimal posi = pos;

				return (int)Math.Floor(posi);
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
				return (position + 1) * 2;
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


