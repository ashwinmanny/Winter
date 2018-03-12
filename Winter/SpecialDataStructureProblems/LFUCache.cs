using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.SpecialDataStructureProblems
{
	public class LFUCache
	{
		Dictionary<int, int> vals;
		Dictionary<int, int> counts;
		Dictionary<int, HashSet<int>> lists;
		int cap;
		int min = -1;
		
		public LFUCache(int capacity) 
		{
			cap = capacity;
			vals = new Dictionary<int, int>();
			counts = new Dictionary<int, int>();
			lists = new Dictionary<int, HashSet<int>>();
			lists.Add(1, new HashSet<int>());
        }

		public int get(int key) 
		{
			if(!vals.ContainsKey(key))
				return -1;
			int count = counts[key];
			counts.Add(key, count+1);
			lists[count].Remove(key);
			if(count==min && lists[count].Count==0)
				min++;
			if(!lists.ContainsKey(count+1))
				lists.Add(count+1, new HashSet<int>());
			lists[count+1].Add(key);
			return vals[key];
        }

		public void set(int key, int value)
		{
			if (cap <= 0)
				return;
			if (vals.ContainsKey(key))
			{
				vals.Add(key, value);
				get(key);
				return;
			}
			if (vals.Count >= cap)
			{
				int evit = lists[min].GetEnumerator().Current ;
				lists[min].Remove(evit);
				vals.Remove(evit);
			}
			vals.Add(key, value);
			counts.Add(key, 1);
			min = 1;
			lists[1].Add(key);
		}
	}
}
