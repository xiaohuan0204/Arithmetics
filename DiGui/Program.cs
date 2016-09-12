using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiGui
{
	class Program
	{
		static void Main(string[] args)
		{
			args=new [] {"a","b","c"};
			Permutation(args,0,args.Length);
			Console.ReadKey();
		}

		public static void Permutation(string[] nums,int m,int n)
		{
			if (m < n - 1)
			{
				Permutation(nums, m + 1, n);
				for (int i = m + 1; i < n; i++)
				{
					Swap(ref nums[m], ref nums[i]);
					Permutation(nums, m + 1, n);
					Swap(ref nums[m], ref nums[i]);
				}
			}
			else
			{
				for (int i = 0; i < nums.Length; i++)
				{
					Console.Write(nums[i]);
				}
				Console.WriteLine();
			}
		}

		private static void Swap(ref string a,ref string b)
		{
			string temp;
			temp = a;
			a = b;
			b = temp;
		}
	}
}
