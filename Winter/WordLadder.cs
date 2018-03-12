using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	public class WordLadder
	{
		public int ladderLength(String beginWord, String endWord, IList<string> wordList)
		{

			List<string> preVisitedStr = new List<string> { beginWord };
			int level = 1;

			if (wordList.Contains(endWord))
			{
				while (preVisitedStr.Count != 0)
				{
					List<string> nextVisitedStr = new List<string>();
					foreach (string visited in preVisitedStr)
					{
						if (IsOnlyOneCharDifferent(endWord, visited))
						{
							return level + 1;
						}

						for (int i = wordList.Count() - 1; i >= 0; i--)
						{
							if (!IsOnlyOneCharDifferent(visited, wordList.ElementAt(i)))
							{
								continue;
							}

							nextVisitedStr.Add(wordList.ElementAt(i));
							wordList.Remove(wordList.ElementAt(i));
						}
					}

					preVisitedStr = nextVisitedStr;
					level++;
				}
			}

			return 0;
		}

		private static bool IsOnlyOneCharDifferent(string str1, string str2)
		{
			// all string have same length
			return str1.Where((t, i) => !t.Equals(str2[i])).Count() == 1;
		}

		public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
		{
			HashSet<String> dict = new HashSet<String>(wordList);
			List<List<String>> res = new List<List<String>>();
			Dictionary<String, List<String>> nodeNeighbors = new Dictionary<String, List<String>>();// Neighbors for every node
			Dictionary<String, int> distance = new Dictionary<String, int>();// Distance of every node from the start node
			List<String> solution = new List<String>();

			dict.Add(beginWord);
			bfs(beginWord, endWord, dict, nodeNeighbors, distance);
			dfs(beginWord, endWord, dict, nodeNeighbors, distance, solution, res);
			return res.ToArray();
		}

		// BFS: Trace every node's distance from the start node (level by level).
		private void bfs(String start, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance) 
		{
			foreach (String str in dict)
			{
				nodeNeighbors.Add(str, new List<String>());
			}

		  Queue<String> queue = new Queue<String>();
		  queue.Enqueue(start);
		  distance.Add(start, 0);

		  while (!(queue.Count == 0)) {
			  int count = queue.Count;
			  bool foundEnd = false;
			  for (int i = 0; i < count; i++) 
			  {
				  String cur = queue.Dequeue();
				  int curDistance = distance[cur];                
				  List<String> neighbors = getNeighbors(cur, dict);

				  foreach (String neighbor in neighbors) 
				  {
					  nodeNeighbors[cur].Add(neighbor);
					  if (!distance.ContainsKey(neighbor)) {// Check if visited
						  distance.Add(neighbor, curDistance + 1);
						  if (end.Equals(neighbor))// Found the shortest path
							  foundEnd = true;
						  else
							  queue.Enqueue(neighbor);
						  }
					  }
				  }

				  if (foundEnd)
					  break;
			  }
         }

		// Find all next level nodes.    
		private List<String> getNeighbors(String node, HashSet<String> dict) 
		{
		  List<String> res = new List<String>();
		  char[] chs = node.ToCharArray();

		  for (char ch ='a'; ch <= 'z'; ch++) 
		  {
			  for (int i = 0; i < chs.Length; i++) 
			  {
				  if (chs[i] == ch) continue;
				  char old_ch = chs[i];
				  chs[i] = ch;
				  if (dict.Contains(new string(chs))) {
					  res.Add(new string(chs));
				  }
				  chs[i] = old_ch;
			  }

          }
          return res;
        }

		// DFS: output all paths with the shortest distance.
		private void dfs(String cur, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance, List<String> solution, List<List<String>> res) 
		{
			solution.Add(cur);
			if (end.Equals(cur)) {
			   res.Add(new List<String>(solution));
			} else {
			   foreach (String next in nodeNeighbors[cur]) {            
					if (distance[next] == distance[cur] + 1) {
						 dfs(next, end, dict, nodeNeighbors, distance, solution, res);
					}
				}
			}           
		   solution.RemoveAt(solution.Count - 1);
		}
	}
}
