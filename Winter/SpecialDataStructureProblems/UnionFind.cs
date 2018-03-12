using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.SpecialDataStructureProblems
{
	class UnionFind
	{

		public static void MakeSet(GraphNode n)
		{
			n.parent = n;
			n.rank = 0;
		}

		public static GraphNode Find(GraphNode n)
		{
			if (n.parent != n)
			{
				n.parent = Find(n.parent);
			}

			return n.parent;
		}

		public static void Union(GraphNode x, GraphNode y)
		{
			if (Find(x.parent).rank == Find(y.parent).rank)
			{
				return;
			}

			if (Find(x.parent).rank > Find(y.parent).rank)
			{
				y.parent = x;
			}
			else if (Find(x.parent).rank < Find(y.parent).rank)
			{
				x.parent = y;
			}
			else
			{
				y.parent = x;
				x.rank++;
			}

		}
	}
}
