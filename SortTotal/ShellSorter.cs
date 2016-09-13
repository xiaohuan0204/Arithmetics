using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	//希尔排序（缩小增量法）
	//属于插入类排序,是将整个无序列分割成若干小的子序列分别进行插入排序。
	//先将要排序的一组数按某个增量d分成若干组，每组中记录的下标相差d.对每组中全部元素进行排序，
	//然后再用一个较小的增量对它进行，在每组中再进行排序。当增量减到1时，整个要排序的数被分成一组，排序完成。
	class ShellSorter
	{
		public static int[] Sort(int[] myArray)
		{
			ShellSort(myArray);
			return myArray;
		}


		private static void ShellSort(int[] nums)
		{
			//取增量
			int step = nums.Length / 2;
			while (step >= 1)
			{
				//无序序列
				for (int i = step; i < nums.Length; i++)
				{
					var temp = nums[i];
					int j;
					//有序序列
					for (j = i - step; j >= 0 && temp < nums[j]; j = j - step)
					{
						nums[j + step] = nums[j];
					}
					nums[j + step] = temp;
				}
				step = step / 2;//循环取第2，3...增量直到step=1
			}
		}
	}
}
