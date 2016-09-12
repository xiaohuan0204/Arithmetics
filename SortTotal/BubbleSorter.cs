using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	class BubbleSorter
	{
		public static int[] Sort(int[] a)
		{
			BubbleSort(a);
			return a;
		}

		private static void BubbleSort(int[] myArray)
		{
			for (int i = 0; i < myArray.Length; i++)//循环的趟数
			{
				for (int j = 0; j < myArray.Length - i - 1; j++)//每次循环的次数
				{
					//比较相邻的元素，将值大的往后移--》每一趟循环结束--》最后一个数是最大的。
					//所以每次循环都比上一个循环的个数少1，即j<myArray.length-i-1
					if (myArray[j] > myArray[j + 1])
					{
						Swap(ref myArray[j], ref myArray[j + 1]);
					}
				}
			}
		}

		//引用参数与值参数
		private static void Swap(ref int left, ref int right)
		{
			int temp;
			temp = left;
			left = right;
			right = temp;
		}
	}
}
