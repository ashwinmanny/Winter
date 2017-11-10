using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.Searching
{
	class BinaryTreeSearch
	{
		int result = 0;
		public int KthSmallest(BinaryTreeNode root, int k)
		{
			KthSmallestHelper(root, ref k);
			return result;
		}

		private void KthSmallestHelper(BinaryTreeNode root, ref int k)
		{
			if (root == null) return;

			KthSmallestHelper(root.left, ref k);
			if (--k == 0)
			{
				result = root.val;
				return;
			}
			KthSmallestHelper(root.right, ref k);
		}

		public IList InorderTraversal(BinaryTreeNode root)
		{
			var res = new List<int>();
			var mystack = new Stack<BinaryTreeNode>();
			findMostLeftNode(root, mystack);

			while (mystack.Count > 0)
			{
				var top = mystack.Pop();
				res.Add(top.val);

				findMostLeftNode(top.right, mystack);
			}

			return res;
		}

		private void findMostLeftNode(BinaryTreeNode root, Stack<BinaryTreeNode> mystack)
		{
			while (root != null)
			{
				mystack.Push(root);
				root = root.left;
			}
		}

		public IList PreorderTraversal(BinaryTreeNode root)
		{
			var values = new List<int>();
			var mystack = new Stack<BinaryTreeNode>();
			if (root != null)
			{
				mystack.Push(root);
			}

			while (mystack.Count > 0)
			{
				var top = mystack.Pop();
				values.Add(top.val);

				if (top.right != null)
				{
					mystack.Push(top.right);
				}
				if (top.left != null)
				{
					mystack.Push(top.left);
				}
			}

			return values;
		}

		public List<BinaryTreeNode> lisOfTreeNode = new List<BinaryTreeNode>();
		public List<BinaryTreeNode> PreorderTraversalRecursion(BinaryTreeNode root)
		{
			if (root == null)
			{
				lisOfTreeNode.Add(new BinaryTreeNode(-1));
			}
			else
			{
				lisOfTreeNode.Add(root);
				this.PreorderTraversalRecursion(root.left);
				this.PreorderTraversalRecursion(root.right);
			}

			return lisOfTreeNode;
		}

		public IList PostorderTraversal(BinaryTreeNode root)
		{
			var values = new List<int>();
			var mystack = new Stack<BinaryTreeNode>();
			if (root != null)
			{
				mystack.Push(root);
			}

			while (mystack.Count > 0)
			{
				var top = mystack.Pop();
				values.Add(top.val);

				if (top.left != null)
				{
					mystack.Push(top.left);
				}
				if (top.right != null)
				{
					mystack.Push(top.right);
				}
			}

			values.Reverse();
			return values;
		}
	}
}
