using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	public class BinaryTreeNode
	{
		public int val;

		public BinaryTreeNode left { get; set; }
		public BinaryTreeNode right { get; set; }

		public BinaryTreeNode(int x)
		{
			val = x;
		}


	}
}
