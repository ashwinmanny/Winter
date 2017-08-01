using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	public class BFS
	{
		public Node BuildGraph()
		{
			Node n = new Node(10);
			Node p = new Node(30);
			Node q = new Node(40);
			Node o = new Node(35);

			n.hasNeigbour(p);
			n.hasNeigbour(q);
			p.hasNeigbour(o);

			Node a = new Node(50);
			Node b = new Node(60);
			Node e = new Node(55);

			q.hasNeigbour(a);
			q.hasNeigbour(b);
			a.hasNeigbour(e);

			Node c = new Node(70);
			Node d = new Node(80);

			b.hasNeigbour(c);
			b.hasNeigbour(d);

			return n;

		}

		public void Traverse(Node root)
		{
			Queue<Node> traverseOrder = new Queue<Node>(); // To hold all nodes in traverse order

			Queue<Node> Q = new Queue<Node>();     // To process all nodes
			HashSet<Node> H = new HashSet<Node>(); // To mark all reached nodes

			Q.Enqueue(root);
			H.Add(root);

			while (Q.Count > 0)
			{
				Node p = Q.Dequeue(); 
				traverseOrder.Enqueue(p);

				foreach (Node node in p.Nodes)
				{
					if (!(H.Contains(node)))
					{
						Q.Enqueue(node);
						H.Add(node);
					}
				}
			}

			while (traverseOrder.Count > 0)
			{
				Node n = traverseOrder.Dequeue();
				Console.WriteLine(n.data);
			}

		}

		public Node Search(Node root, int nodeToSearchFor)
		{
			Queue<Node> Q = new Queue<Node>();
			HashSet<Node> H = new HashSet<Node>();
			Q.Enqueue(root);
			H.Add(root);

			while (Q.Count > 0)
			{
				Node p = Q.Dequeue();
				if (p.data == nodeToSearchFor)
					return p;
				foreach (Node node in p.Nodes)
				{
					if (!H.Contains(node))
					{
						Q.Enqueue(node);
						H.Add(node);
					}
				}
			}
			return null;
		}
	}
}
