using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.DFSProblems
{
	public class Solution
	{
		//----------1. Same Tree----------------------------//
		public bool IsSameTree(BinaryTreeNode p, BinaryTreeNode q)
		{
			if(p == null && q == null)
			{
				return true;
			}
			else if (p == null || q == null)
			{
				return false;
			}
			
			return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
		}
		
		//----------2. Symmetric Tree-----------------------//

		public bool IsSymmetric(BinaryTreeNode root)
		{
			return root == null || IsSymmetricRecursion(root.left, root.right);
		}

		public bool IsSymmetricRecursion(BinaryTreeNode p, BinaryTreeNode q)
		{
			if (p == null && q == null)
			{
				return true;
			}
			else if (p == null || q == null)
			{
				return false;
			}

			if(p.val != q.val)
			{
				return false;
			}

			return IsSymmetricRecursion(p.left, q.right) && IsSymmetricRecursion(p.right, q.left);
		}

		//----------3. Maximum depth of binary tree---------//

		public int MaxDepth(BinaryTreeNode root)
		{
			if (root == null)
			{
				return 0;
			}
			else
			{
				return  Math.Max(MaxDepth(root.left),MaxDepth(root.right))+1;
			}
		}

		//----------4. Binary Tree Paths-------------------//
		public static IList<string> BinaryTreePaths(BinaryTreeNode root)
		{
			List<string> list = new List<string>();

			if (root == null)
			{
				list.Add("null");
				return list;
			}

			findPaths(root, list, root.val + "");
			return list;
		}

		private static void findPaths(BinaryTreeNode root, List<string> list, string current)
		{
			if (root.left == null && root.right == null)
			{
				list.Add(current);
				return;
			}

			if (root.left != null)
			{
				findPaths(root.left, list, current + "->" + root.left.val);
			}

			if (root.right != null)
			{
				findPaths(root.right, list, current + "->" + root.right.val);
			}
		}

		//----------5. Path sum ---------------------------//

		public bool HasPathSum(BinaryTreeNode root, int sum)
		{
			if (root == null)
			{
				return false;
			}
			if (root.left == null && root.right == null)
			{
				return sum == root.val;
			}

			return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
		}

		//----------6. Minimum depth of binary tree---------//

		public int MinDepth(BinaryTreeNode root)
		{
			if (root == null)
			{
				return 0;
			}
			if (root.left != null && root.right != null)
			{
				return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
			}
			else if (root.left != null)
			{
				return MinDepth(root.left) + 1;
			}
			else 
			{
				return MinDepth(root.right) + 1;
			}
		}

		//----------7. Balanced Binary Tree---------//

		public bool IsBalanced(BinaryTreeNode root)
		{
			if (root == null)
			{
				return true;
			}

			if (Math.Abs(GetHeight(root.left) - GetHeight(root.right)) < 2)
			{
				return IsBalanced(root.left) && IsBalanced(root.right);
			}

			return false;
		}

		private int GetHeight(BinaryTreeNode root)
		{
			if (root == null)
			{
				return 0;
			}

			return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
		}

		//----------8. Find Friend circle---------//      

		public int FindCircleNum(int[,] M)
		{
			Boolean[] visited = new Boolean[M.Length];

			int noOfCircles = 0;

			for (int i = 0; i < M.GetLength(0); i++)
			{
				if (visited[i] == false)
				{
				  findFriendsDFS(M, visited, i);
				  noOfCircles++;
				}
			}
			return noOfCircles;
		}

		public void findFriendsDFS(int[,] M, Boolean[] visited, int i)
		{
			for (int j = 0; j < M.GetLength(0); j++)
			{
				if(M[i,j] == 1 && visited[j] == false)
				{
					visited[j] = true;
					findFriendsDFS(M, visited, j);
				}
			}
		}                                                          

	}
}
