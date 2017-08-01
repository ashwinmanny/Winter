using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	class Node1
	{	
		public Node1 left, right;
		public int data;
		public Node1(int data)
		{
			this.data = data;
			left = right = null;
		}
	}
}
