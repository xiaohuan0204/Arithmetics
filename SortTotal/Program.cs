using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTotal
{
	class Program
	{
		static void Main(string[] args)
		{
			Test(5);
			//EfficiencyTest(10000, 10, "InsertSorter");

		}

		//测试排序算法的正确性
		private static void Test(int n)
		{
			int[] num = GenerateRandomNumber(n).ToArray();
			Console.WriteLine("排序前：");
			foreach (int result in num)
			{
				Console.WriteLine(result);
			}

			//int[] afternum = BubbleSorter.Sort(num);
			//int[] afternum = CockTailSorter.Sort(num);
			//int[] afternum = HeapSorter.Sort(num);
			int[] afternum = InsertSorter.Sort(num);
			//int[] afternum = QuickSorter.Sort(num);
			Console.WriteLine("排序后：");
			foreach (int result in afternum)
			{
				Console.WriteLine(result);
			}
			Console.ReadKey();
		}


		private static List<int> GenerateRandomNumber(int length)
		{
			List<int> newRandom = new List<int>();
			Random random = new Random();
			for (int i = 0; i < length; i++)
			{
				newRandom.Add(random.Next());
			}
			return newRandom;
		}


		//private static void EfficiencyTest(int i, int j, string name)
		//{
		//	double AverageTime = 0;
		//	string Sname = null;
		//	for (int k = 0; k < j; k++)
		//	{
		//		int[] nums = GenerateRandomNumber(i).ToArray();
		//		Stopwatch stopwatch = new Stopwatch();
		//		stopwatch.Start();
		//		DateTime datestart = DateTime.Now;
		//		switch (name)
		//		{
		//			case "InsertSorter":
		//				InsertSorter.Sort(nums);
		//				Sname = "InsertSorter";
		//				break;
		//			case "HeapSorter":
		//				HeapSorter.Sort(nums);
		//				Sname = "HeapSorter";
		//				break;
		//			case "BubbleSorter":
		//				BubbleSorter.Sort(nums);
		//				Sname = "BubbleSorter";
		//				break;
		//			case "CockTailSorter":
		//				CockTailSorter.Sort(nums);
		//				Sname = "CockTailSorter";
		//				break;
		//			case "QuickSorter":
		//				QuickSorter.Sort(nums);
		//				Sname = "QuickSorter";
		//				break;
		//		}
		//		stopwatch.Stop();
		//		AverageTime = (DateTime.Now - datestart).TotalMilliseconds;
		//	}
		//	Double timespan = AverageTime / j;
		//	string str = Sname + "排序" + i + "个数" + j + "次所用平均时间为:" + timespan + "毫秒";
		//	Console.WriteLine(str);
		//	Console.ReadKey();
		//}
	}
}
