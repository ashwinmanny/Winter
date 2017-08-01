using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRCrackingTheCodingI
{
	public abstract class GenericNode
	{
		public List<GenericNode> adjacent;
		public int data;
		public bool visted;

		public GenericNode()
		{
		}

		public GenericNode(int data)
		{
			this.data = data;
			adjacent = new List<GenericNode>();
		}

		public void hasNeigbour(GenericNode n)
		{
			adjacent.Add(n);
		}
	}

	public class GenericNodeBFS : GenericNode
	{
		public HashSet<GenericNodeBFS> adjacent;
		public int data;
		public bool visted;

		public GenericNodeBFS(int data)
		{
			this.data = data;
			this.adjacent = new HashSet<GenericNodeBFS>();
		}

		public void hasNeigbour(GenericNodeBFS n) //unidirectional
		{
			adjacent.Add(n);
			n.adjacent.Add(this);
		}
	}
}
