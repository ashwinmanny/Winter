using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.LinkedListsProblems
{
	public class LinkedListSolution
	{

		static public LinkedListNode MergeKLists(LinkedListNode[] lists)
		{
			return MergeKListsHelper(lists, 0, lists.Length-1);
		}

		static public LinkedListNode MergeKListsHelper(LinkedListNode[] lists, int low, int high)
		{
			if(low > high)  return null;
			if (low == high) return lists[low]; 
			int middle = (high - low) / 2 + low;

			LinkedListNode left = MergeKListsHelper(lists, low, middle);
			LinkedListNode right = MergeKListsHelper(lists, middle + 1, high);

			return Merge2Lists(left, right);
		}

		static public LinkedListNode Merge2Lists(LinkedListNode left, LinkedListNode right)
		{
			if (left == null) { return right; }
			if (right == null) { return left; }

			LinkedListNode fakeHead = new LinkedListNode(-1);
			LinkedListNode start = fakeHead;

			while (left != null && right != null)
			{
				if (left.data < right.data)
				{
					start.next = left;
					start = start.next;

					left = left.next;
				}
				else
				{
					start.next = right;
					start = start.next;

					right = right.next;
				}
			}

			if (left != null)
			{
				start.next = left;
			}

			if (right != null)
			{
				start.next = right;
			}

			return fakeHead;
		}

		static public LinkedListNode ReverseKGroup(LinkedListNode head, int k)
		{

			return null;
		}
	}

	public class LinkedListNode
	{
		public int data {get; set;}
		public LinkedListNode next;

		public LinkedListNode(int x)
		{
			this.data = x;
		}
	}

	public class LRUCache
	{
		int Capacity { get; set; }

		LinkedList<KeyValuePair<int, int>> doubleyLinkedList = new LinkedList<KeyValuePair<int, int>>();

		public LRUCache(int capacity)
		{
			this.Capacity = capacity;
		}

		public int Get(int key)
		{
			int output = -1;

			var found = this.doubleyLinkedList.Where(x => x.Key == key).ToList();

			if (!(found.Count == 0))
			{
				output = found[0].Value;

				this.doubleyLinkedList.Remove(found[0]);
				this.doubleyLinkedList.AddFirst(found[0]);
			}

			return output;
		}

		public void Put(int key, int value)
		{
			KeyValuePair<int, int> keyValue = new KeyValuePair<int, int>(key, value);

			int val = Get(key);

			if (this.Capacity != this.doubleyLinkedList.Count)
			{
				if (val == -1)
				{
					this.doubleyLinkedList.AddFirst(keyValue);
				}
				else
				{
					KeyValuePair<int, int> oldKeyValue = new KeyValuePair<int, int>(key, val);
					this.doubleyLinkedList.Remove(oldKeyValue);
					this.doubleyLinkedList.AddFirst(keyValue);
				}
					
			}
			else
			{
				if (val == -1)
				{
					this.doubleyLinkedList.RemoveLast();
					this.doubleyLinkedList.AddFirst(keyValue);
				}
				else
				{
					KeyValuePair<int, int> oldKeyValue = new KeyValuePair<int, int>(key, val);
					this.doubleyLinkedList.Remove(oldKeyValue);
					this.doubleyLinkedList.AddFirst(keyValue);
				}
			}
		}
	}
}
