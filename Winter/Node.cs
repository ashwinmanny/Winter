using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	public class Node
	{
		public int data { get; set; }
		List<Node> NodeList = new List<Node>();

		public Node(int x)
		{
			this.data = x;
		}

		public List<Node> Nodes
		{
			get
			{
				return NodeList;
			}
		}

		public void hasNeigbour(Node n)
		{
			NodeList.Add(n);
		}
		
	}
}
