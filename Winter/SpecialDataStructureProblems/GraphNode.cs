using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.SpecialDataStructureProblems
{
	class GraphNode
	{
		public int rank {get; set;}
		public GraphNode parent {get; set;}
		public int val { get; set; }

		public GraphNode(int n)
		{
			this.val = n;
		}
	}
}
