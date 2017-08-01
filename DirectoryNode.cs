using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	public class DirectoryNode
	{
		public string data { get; set; }
		public List<DirectoryNode> DirectoryNodesList = new List<DirectoryNode>();

		public DirectoryNode(string x)
		{
			this.data = x;
		}

		public List<DirectoryNode> GetNodesList
		{
			get
			{
				return this.DirectoryNodesList;
			}
		}

		public void hasNeigbour(DirectoryNode n)
		{
			GetNodesList.Add(n);
		}
	}
}
