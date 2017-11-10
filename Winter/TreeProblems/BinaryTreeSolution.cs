using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.TreeProblems
{
	class BinaryTreeSolution
	{

		// Encodes a tree to a single string

		//(Preorder serialize)
		//List<BinaryTreeNode> list = new List<BinaryTreeNode>();
		/*public void serialize(BinaryTreeNode root)
		{
			if (root == null)
			{
				list.Add(new BinaryTreeNode(-1));
			}
			else
			{
				list.Add(root);
				serialize(root.left);
				serialize(root.right);
			}

		}*/


		//(Inorder serialize)
		public string serialize(BinaryTreeNode root)
		{
			var serializedString = new StringBuilder();
			var queue = new Queue<BinaryTreeNode>();
			queue.Enqueue(root ?? null);

			while (queue.Count != 0)
			{
				var size = queue.Count;
				for (int i = 0; i < size; i++)
				{
					var top = queue.Dequeue();
					serializedString.Append(top == null ? '#' : (char)(top.val + '0'));
					if (top != null)
					{
						queue.Enqueue(top.left);
						queue.Enqueue(top.right);
					}
				}
			}

			return serializedString.ToString();
		}

		// Decodes your encoded data to tree.

		//(Preorder deserialize)
		/*public BinaryTreeNode deserialize(BinaryTreeNode list){
			if (list.Count <= 0)
			{
				return null;
			}

			BinaryTreeNode root = list[0];
			DeserializeBinaryTreeRecursion(list, root);
			return root;

		}

		private int start = 0;
		private void DeserializeBinaryTreeRecursion(List<BinaryTreeNode> listofNodes, BinaryTreeNode root)
		{
			if (listofNodes[start].val == -1)
			{
				return;
			}
			start++;

			DeserializeBinaryTreeRecursion(listofNodes, root.left);
			DeserializeBinaryTreeRecursion(listofNodes, root.right);
		}
		*/

		//(Inorder deserialize)
		public BinaryTreeNode deserialize(string data)
		{

			if (string.IsNullOrEmpty(data)) return null;
			if (data[0] == '#') return null;
			var queue = new Queue<BinaryTreeNode>();
			var root = new BinaryTreeNode(data[0] - '0');
			queue.Enqueue(root);
			var index = 1;
			while (queue.Count != 0)
			{
				var size = queue.Count;
				for (int i = 0; i < size; i++)
				{
					var top = queue.Dequeue();
					top.left = data[index] == '#' ? null : new BinaryTreeNode(data[index] - '0');
					if (top.left != null) queue.Enqueue(top.left);
					index++;
					top.right = data[index] == '#' ? null : new BinaryTreeNode(data[index] - '0');
					if (top.right != null) queue.Enqueue(top.right);
					index++;
				}
			}

			return root;
		}

	}
}
