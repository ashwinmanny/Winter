using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	public class DFS
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

		public BinaryTreeNode BuildBinaryTreeGraph()
		{
			BinaryTreeNode n = new BinaryTreeNode(1);
			BinaryTreeNode o = new BinaryTreeNode(2);
			BinaryTreeNode p = new BinaryTreeNode(3);
			BinaryTreeNode q = new BinaryTreeNode(4);
			BinaryTreeNode r = new BinaryTreeNode(5);
			BinaryTreeNode s = new BinaryTreeNode(6);
			BinaryTreeNode t = new BinaryTreeNode(7);

			n.left = o;
			n.right = p;
			o.left = q;
			o.right = r;
			p.left = s;
			p.right = t;

			return n;

		}


		public void Traverse(Node root)
		{
			if (root == null)
			{
				return;
			}

			Console.WriteLine(root.data);

			if(root.Nodes != null)
			{
				foreach (Node n in root.Nodes)
				{
					Traverse(n);
				}
			}
		}

		public void BinaryTreeTraverse(BinaryTreeNode root)
		{
			if (root == null)
			{
				return;
			}

			Console.WriteLine(root.val);

			BinaryTreeTraverse(root.left);
			BinaryTreeTraverse(root.right);

		}
	}
}
