using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	//插入排序  
	class InsertSorter
	{
		public static int[] Sort(int[] a)
		{
			InsertSort(a);
			return a;
		}

		private static void InsertSort(int[] myArray)
		{
			//插入排序是把无序列的数一个一个插入到有序的数
			//先默认下标为0这个数已经是有序
			for (int i = 0; i < myArray.Length; i++)
			{
				int insertVal = myArray[i];//记住这个要插入的数
				int insertIndex = i - 1;//前一个下标数，该数字要准备插入到序列中

				while (insertIndex>=0 && insertVal<myArray[insertIndex])//小于升序，大于降序
				{
					myArray[insertIndex + 1] = myArray[insertIndex];//把比插入数大的数往后移
					insertIndex--;//指针继续往后移，下一个插入数要与这个指针数做比较
				}
				myArray[insertIndex + 1] = insertVal;
			}
		}
	}
}
