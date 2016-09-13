using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	//归并排序
	//第一： “分”, 就是将数组尽可能的分，一直分到原子级别。
	//第二： “并”，将原子级别的数两两合并排序，最后产生结果。
	class MergeSorter
	{
		public static int[] Sort(int[] myArray)
		{
			MergeSort(myArray,new int[myArray.Length],0,myArray.Length-1);
			return myArray;
		}

		/// <summary>
		/// 数组排序
		/// </summary>
		/// <param name="nums">待排序的数组</param>
		/// <param name="temp">临时存放的位置</param>
		/// <param name="left">序列段开始的位置</param>
		/// <param name="right">序列段结束的位置</param>
		private static void MergeSort(int[] nums,int[] temp,int leftStart,int rightEnd)
		{
			int length = rightEnd - leftStart + 1;
			if (leftStart>rightEnd)
			{
				return;
			}
			if (leftStart<rightEnd)
			{
				int tempIndex = leftStart;
				int middle = (leftStart + rightEnd)/2;//取分割点

				//分别对左右两段的分段排序
				MergeSort(nums, temp, leftStart, middle);
				MergeSort(nums,temp,middle+1,rightEnd);

				int leftEnd = middle;
				int rightStart = middle + 1;

				while (leftStart<=leftEnd && rightStart<=rightEnd)
				{
					if (nums[leftStart] >= nums[rightStart]) //比较左右分段的大小,将较小者放入临时数组temp.
					{
						temp[tempIndex++] = nums[rightStart++];
					}
					else
					{
						temp[tempIndex++] = nums[leftStart++];
					}
				}

				//判断左序列是否结束
				while (leftStart <= leftEnd)
				{
					temp[tempIndex++] = nums[leftStart++];
				}

				//判断右序列是否结束
				while (rightStart<=rightEnd)
				{
					temp[tempIndex++] = nums[rightStart++];
				}

				while (length>0)
				{
					nums[rightEnd] = temp[rightEnd];
					rightEnd--;
					length--;
				}
			}
		}
	}
}

