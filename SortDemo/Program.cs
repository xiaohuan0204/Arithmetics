using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arraylist = new[] {1, 4, 56, 34, 23, 12, 7};
			//InsertSorter sorter=new InsertSorter();
			//sorter.Sort(arraylist);
			//MaoPaoSorter maoPao=new MaoPaoSorter();
			//maoPao.Sort(arraylist);
			MaoPaoSorter1 mao=new MaoPaoSorter1();
			mao.Sort();
		}


        //插入排序
        public class InsertSorter
        {
            public void Sort(int[] list)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    int t = list[i];
                    int j = i;
                    while ((j>0) && (list[j-1]>t))
                    {
                        list[j] = list[j - 1];
                        --j;
                    }
                    list[j] = t;
                }
            }
        }

        //冒泡排序
        public class MaoPaoSorter
        {
            public void Sort(int[] list)
            {
	            int length = list.Length;
	            for (int i = 0; i < length-1; i++)
	            {
		            for (int j = 0; j < length-1-i; j++)
		            {
			            if (list[j]>list[j+1])
			            {
				            int temp = list[j];
				            list[j] = list[j + 1];
				            list[j + 1] = temp;
			            }
		            }
	            }
            }
        }

		//冒泡排序算法（它重复地走访过要排序的数列，一次比较两个元素，如果他们的顺序错误就把他们交换过来。走访数列的工作是重复地进行直到没有再需要交换，也就是说该数列已经排序完成。
	    public  class MaoPaoSorter1
	    {
		    public void Sort()
		    {
				Console.WriteLine("请输入6个正整数：");
				int[] myintArray=new int[6];
			    for (int i = 0; i < myintArray.Length; i++)
			    {
				    myintArray[i] = int.Parse(Console.ReadLine());//循环入6个正整数,按enter切换
			    }
				
				//按正序排列
			    for (int i = 0; i < myintArray.Length-1; i++)//外层控制循环次数
			    {
				    for (int j = 0; j < myintArray.Length-i-1; j++)//内层循环用于交换相邻要素
				    {
					    int temp;
					    if (myintArray[j]>myintArray[j+1])
					    {
						    temp = myintArray[j + 1];
						    myintArray[j + 1] = myintArray[j];
						    myintArray[j] = temp;
					    }
				    }
			    }
				Console.WriteLine("正序排列为：");
			    foreach (int outint in myintArray)
			    {
				    Console.Write(outint+"\t");
			    }
				Console.WriteLine();



				//按倒序排列
			    for (int i = 0; i < myintArray.Length-1; i++)
			    {
				    for (int j = 0; j < myintArray.Length-i-1; j++)
				    {
					    int temp;
					    if (myintArray[j+1]>myintArray[j])
					    {
						    temp = myintArray[j];
						    myintArray[j] = myintArray[j + 1];
						    myintArray[j + 1] = temp;
					    }
				    }
			    }
				Console.WriteLine("倒序为：");
			    foreach (int outint in myintArray)
			    {
				    Console.Write(outint+"\t");
			    }
			    Console.ReadKey();
		    }
	    }

    }
}
