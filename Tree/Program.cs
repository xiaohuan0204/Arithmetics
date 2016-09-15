using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tree
{
	//二叉树：若根节点有左子树，则左子树的所有节点都比根节点小；若根节点有右子树，则右子树的所有节点都比根节点大。
	//二叉树的遍历分为：
	//1.先序首先遍历根节点，然后是左子树，然后是右子树。
	//2.中序首先遍历左子树，然后是根节点，最后是右子树。
	//3.后序首先遍历左子树，然后是右子树，最后是根节点
	class Program
	{
		static void Main(string[] args)
		{
			List<int> list=new List<int>() {30,20,45,65,80,70,10,90};

			//创建二叉树遍历树
			BSTree bsTree = CreateBST(list);
			Console.Write("中序遍历的原始数据：");
			//中序遍历
			LDR_BST(bsTree);
			Console.WriteLine("\n---------------------------------------------------");

			//查找一个节点
			Console.WriteLine("\n二叉树种是否包含20："+SearchBST(bsTree,20));
			Console.WriteLine("---------------------------------------------------");

			bool isExcute = false;
			//插入一个节点
			InsertBST(bsTree,50,ref isExcute);
			Console.Write("\n插入到二叉树种50，中序遍历后的数据：");
			LDR_BST(bsTree);//中序遍历
			Console.WriteLine("\n---------------------------------------------------");

			//删除一个节点
			Console.Write("删除叶子节点 50，中序遍历后：");
			DeleteBST(ref bsTree,45);
			LDR_BST(bsTree);//中序遍历
			Console.WriteLine("\n---------------------------------------------------");

			Console.ReadKey();

		}


		//定义一个二叉树排序结构
		public class BSTree
		{
			public int data;
			public BSTree left;
			public BSTree right;
		}

		/// <summary>
		/// 二叉排序树的插入操作
		/// </summary>
		/// <param name="bsTree">排序树</param>
		/// <param name="key">插入数</param>
		/// <param name="isExcute">是否执行了if语句</param>
		static void InsertBST(BSTree bsTree,int key,ref bool isExcute)
		{
			if (bsTree==null)
			{
				return;
			}
			//如果父节点大于key,则遍历左子树
			if (bsTree.data>key)
			{
				InsertBST(bsTree.left,key,ref isExcute);
			}
			else
			{
				InsertBST(bsTree.right,key,ref isExcute);
			}

			if (!isExcute)
			{
				//构建当前的节点
				BSTree current=new BSTree()
				{
					 data = key,
					 right = null,
					 left = null
				};
				//插入到父节点的当前元素
				if (bsTree.data > key)
				{
					bsTree.left = current;
				}
				else
				{
					bsTree.right = current;
				}
				isExcute = true;
			}
		}

		/// <summary>
		/// 创建二叉树
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		static BSTree CreateBST(List<int> list)
		{
			//创建根节点
			BSTree bsTree=new BSTree()
			{
				data = list[0],
				left = null,
				right = null
			};

			for (int i = 1; i < list.Count; i++)
			{
				bool isExcute = false;
				InsertBST(bsTree,list[i],ref isExcute);
			}
			return bsTree;
		}

		/// <summary>
		/// 在排序二叉树中搜索子节点
		/// </summary>
		/// <param name="bsTree"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		static bool SearchBST(BSTree bsTree,int key)
		{
			//判断bsTree是否为空，为空说明已经遍历到头了
			if (bsTree==null)
			{
				return false;
			}

			if (bsTree.data==key)
			{
				return true;
			}

			if (bsTree.data>key)
			{
				return SearchBST(bsTree.left, key);
			}
			else
			{
				return SearchBST(bsTree.right, key);
			}
		}

		/// <summary>
		/// 中序遍历二叉排序树
		/// </summary>
		/// <param name="bsTree"></param>
		static void LDR_BST(BSTree bsTree)
		{
			if (bsTree!=null)
			{
				//遍历左子树
				LDR_BST(bsTree.left);
				//输入节点数
				Console.Write(bsTree.data + " ");
				//遍历右子树
				LDR_BST(bsTree.right);
			}
		}

		/// <summary>
		/// 删除二叉树中指定的key节点
		/// </summary>
		/// <param name="bsTree"></param>
		/// <param name="key"></param>
		static void DeleteBST(ref BSTree bsTree,int key)
		{
			if (bsTree==null)
			{
				return;
			}
			if (bsTree.data==key)
			{
				//1.被删节点是叶子节点
				if (bsTree.left==null && bsTree.right==null)
				{
					bsTree = null;
					return;
				}
				//2.被删节点有左孩子没右孩子
				if (bsTree.left!=null && bsTree.right==null)
				{
					bsTree = bsTree.left;
					return;
				}
				//3.被删节点有右孩子没左孩子
				if (bsTree.right!=null && bsTree.left==null)
				{
					bsTree = bsTree.right;
					return;
				}
				//4.被删节点有两个孩子
				if (bsTree.left!=null && bsTree.right!=null)
				{
					BSTree lasParentnode = bsTree;//用来保存右孩子的最左节点的父节点
					var node = bsTree.right;//被删除节点的右孩子
					//找到右子树中最左的节点,
					while (node.left!=null)
					{
						lasParentnode = node;//保存左子树的父节点
						//遍历左子树
						node = node.left;
					}

					bsTree.data = node.data;

					if (lasParentnode.right == node) //删除节点的右节点没有左节点的时候
					{
						bsTree.right = node.right;
					}
					else
					{
						if (lasParentnode.left==node)//删除节点的右节点有左节点的时候
						{
							lasParentnode.left = node.right;
						}
					}
					node = null;//将换位到删除节点去的右子树的最左子树赋值为空
				}
			}
			if (bsTree.data>key)
			{
				DeleteBST(ref bsTree.left,key);
			}
			else
			{
				DeleteBST(ref bsTree.right,key);
			}
		}
	}
}
