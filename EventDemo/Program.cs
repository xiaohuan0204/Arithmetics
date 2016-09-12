using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			//实例化朋友对象
			Friend friend1=new Friend("张三");
			Friend friend2 = new Friend("李四");
			Friend friend3 = new Friend("王五");

			Bridegroom bridegroom=new Bridegroom();

			bridegroom.Marryevent+=new Bridegroom.MarryHandler(friend1.SendMessage);
			bridegroom.Marryevent += (friend3.SendMessage);
			bridegroom.OnMarriage("朋友们，请准时参加婚礼！");
			Console.WriteLine("-------------------------------------------");

			//取消事件
			bridegroom.Marryevent -= (friend3.SendMessage);
			bridegroom.OnMarriage("朋友们，请准时参加婚礼！");

			Console.Read();

		}

		//事件发布者角色
		public class Bridegroom
		{
			//自定义委托
			public delegate void MarryHandler(string msg);

			//用自定义的委托定义事件
			public event MarryHandler Marryevent;

			public void OnMarriage(string msg)
			{
				//判断是否绑定了事件处理方法
				if (Marryevent!=null)
				{
					Marryevent(msg);//触发事件
				}
			}
		}

		public class Friend
		{
			public string Name;

			public Friend(string name)
			{
				Name = name;
			}

			public void SendMessage(string message)
			{
				Console.WriteLine(message);//输出通知信息
				Console.WriteLine(this.Name+"收到了，到时候准时参加。");//对事件做出处理
			}
		}

	}
}
