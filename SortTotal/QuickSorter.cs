using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	//快速排序不是一种稳定的排序算法
	//基本思想：通过一趟排序将要排序的数据分割成独立的两部分，其中一部分的所有数据都比另外一部分的所有数据都要小，
	//然后再按此方法对这两部分数据分别进行快速排序，整个排序过程可以递归进行，以此达到整个数据变成有序序列。
	class QuickSorter
	{
		private static int[] myArray;
		private static int arraySize;
		public static int[] Sort(int[] a)
		{
			arraySize = a.Length;
			QuickSort(a, 0, arraySize - 1);
			return a;
		}
		//设要排序的数组是A[0]……A[N-1]，首先任意选取一个数据（通常选用数组的第一个数）作为关键数据，
		//然后将所有比它小的数都放到它前面，所有比它大的数都放到它后面，这个过程称为一趟快速排序。
		private static void QuickSort(int[] myArray, int left, int right)
		{
			int i, j, s;
			if (left < right)
			{
				i = left - 1;
				j = right + 1;
				s = myArray[(i + j) / 2];
				while (true)
				{
					while (myArray[++i] < s) ;
					while (myArray[--j] > s) ;
					if (i >= j)
						break;
					Swap(ref myArray[i], ref myArray[j]);
				}
				QuickSort(myArray, left, i - 1);
				QuickSort(myArray, j + 1, right);
			}
		}

		private static void Swap(ref int left, ref int right)
		{
			int temp;
			temp = left;
			left = right;
			right = temp;
		}
	}
}
