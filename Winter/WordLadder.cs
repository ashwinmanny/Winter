using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	public class WordLadder
	{
		public int ladderLength(String beginWord, String endWord, ISet<string> wordList)
		{

			List<string> preVisitedStr = new List<string> { beginWord };
			int level = 1;

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

			return 0;
		}

		private static bool IsOnlyOneCharDifferent(string str1, string str2)
		{
			// all string have same length
			return str1.Where((t, i) => !t.Equals(str2[i])).Count() == 1;
		}

	}
}
