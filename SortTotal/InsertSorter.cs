using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	//插入排序  
	//⒈ 从第一个元素开始，该元素可以认为已经被排序
	//⒉ 取出下一个元素，在已经排序的元素序列中从后向前扫描
	//⒊ 如果该元素（已排序）大于新元素，将该元素移到下一位置
	//⒋ 重复步骤3，直到找到已排序的元素小于或者等于新元素的位置
	//⒌ 将新元素插入到下一位置中
	//⒍ 重复步骤2 ~5
	class InsertSorter
	{
		public static int[] Sort(int[] a)
		{
			InsertSort2(a);
			return a;
		}

		//1.
		private static void InsertSort(int[] myArray)
		{
			//插入排序是把无序列的数一个一个插入到有序的数
			//先默认下标为0这个数已经是有序
			for (int i = 0; i < myArray.Length; i++)
			{
				int insertVal = myArray[i];//记住这个要插入的数
				int insertIndex = i - 1;//前一个下标数，该数字要准备插入到序列中

				while (insertIndex >= 0 && insertVal < myArray[insertIndex])//小于升序，大于降序
				{
					myArray[insertIndex + 1] = myArray[insertIndex];//把比插入数大的数往后移
					insertIndex--;//指针继续往后移，下一个插入数要与这个指针数做比较
				}
				myArray[insertIndex + 1] = insertVal;
			}
		}

		//2.
		private static void InsertSort2(int[] myArray)
		{
			for (int i = 0; i < myArray.Length; i++)
			{
				var temp = myArray[i];
				int j;
				for (j = i - 1; j >= 0 && temp < myArray[j]; j--)
				{
					myArray[j + 1] = myArray[j];
				}
				myArray[j + 1] = temp;
			}
		}
	}
}
