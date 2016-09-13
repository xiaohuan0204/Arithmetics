using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	//选择排序
	//每一趟从待排序的数据元素中选出最小（或最大）的一个元素，顺序放在已排好序的数列的最前（或最后），直到全部待排序的数据元素排完
	class SelectSorter
	{
		public static int[] Sort(int[] myArray)
		{
			SelectSort(myArray);
			return myArray;
		}


		private static void SelectSort(int[] nums)
		{
			//要遍历的次数
			for (int i = 0; i < nums.Length-1; i++)
			{
				int tempIndex = i;//假设tempIndex的值最小
				for (int j = i+1; j < nums.Length; j++)
				{
				    //如果tempIndex下标的值大于j下标的值,则记录较小值下标j
					if (nums[tempIndex]>nums[j])
					{
						tempIndex = j;
					}
				}
				Swap(ref nums[tempIndex],ref nums[i]);
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
