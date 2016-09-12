using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	//双冒泡排序、搅拌排序或涟漪排序
	class CockTailSorter
	{
		private static int[] myArray;
		private static int arraySize;
		public static int[] Sort(int[] myArray)
		{
			arraySize = myArray.Length;
			CockTailSort(myArray);
			return myArray;
		}

		private static void CockTailSort(int[] myArray)
		{
			int low, up, index, a;//a?
			low = 0;//数组起始索引
			up = myArray.Length - 1;//数组索引最大值
			index = low;//临时变量
						//判断数组中是否有多个元素
			while (up > low)//每一次进入while循环都会找出相应范围内最大最小的元素并分别放到相应的位置
			{
				//进入for循环会将索引限定范围最大的元素放到最右边
				for (int i = low; i < up; i++)//从上向下扫描
				{
					if (myArray[i] > myArray[i + 1])
					{
						Swap(ref myArray[i], ref myArray[i + 1]);
						index = i;//记录当前的索引
					}
				}
				up = index;//记录最后一个交换的位置
						   //进入for循环会将索引限定范围最小的元素放到最左边
				for (int i = up; i < low; i++)//最后一个交换位置从下往上扫描
				{
					if (myArray[i] < myArray[i - 1])
					{
						Swap(ref myArray[i], ref myArray[i - 1]);
						index = i;
					}
				}
				low = index;//记录最后一个交换的位置
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
