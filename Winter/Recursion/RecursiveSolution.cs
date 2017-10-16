using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.Recursion
{
	public class RecursiveSolution
	{
		public int fibonacci(int n)
		{
			if (n == 0)
			{
				return 0;
			}
			else if (n == 1)
			{
				return 1;
			}
			else
			{
				return fibonacci(n - 1) + fibonacci(n - 2);
			}
		}

		//----------1. N-Queen Problem----------------------//

		public IList<string[]> SolveNQueens(int n)
		{
			var res = new List<string[]>();
			var queens = new List<Tuple<int, int>>();
			PlaceQueens(n, queens, res);

			return res;
		}

		private void PlaceQueens(int n, List<Tuple<int, int>> queens, IList<string[]> res)
		{
			// Display for queen position once all positions are set
			if (queens.Count == n)
			{
				var strarray = new string[n];
				for (int i = 0; i < n; i++)
				{
					var stringbuilder = new StringBuilder();
					for (int j = 0; j < n; j++)
					{
						stringbuilder.Append(queens[i].Item2 == j ? 'Q' : '.');
					}
					strarray[i] = stringbuilder.ToString();
				}
				res.Add(strarray);
				return;
			}

			//Check placing queen for every row
			for (int i = 0; i < n; i++)
			{
				if (queens.Count != i)
				{
					continue;
				}

				//check if queen at i-th row can be placed at j-th column.
				for (int j = 0; j < n; j++)
				{
					if (canAdd(queens, i, j))
					{
						queens.Add(new Tuple<int, int>(i, j));
						PlaceQueens(n, queens, res);
						queens.Remove(new Tuple<int, int>(i, j));
					}
				}
			}
		}

		private bool canAdd(List<Tuple<int, int>> queens, int x2, int y2)
		{
			foreach (var queen in queens)
			{
				// check if it is in same row OR if it is in same column OR if it is in same slope
				if ((queen.Item1 == x2) || (queen.Item2 == y2) || (Math.Abs(queen.Item1 - x2) == Math.Abs(queen.Item2 - y2)))
				{
					return false;
				}

			}

			return true;
		}

		//----------2. Climbing staircase----------------------//

		public int GetWays(int n)
		{
			if (n == 0)
			{
				return 1;
			}
			if (n == 1)
			{
				return 1;
			}
			if (n == 2)
			{
				return 2;
			}

			return GetWays(n - 1) + GetWays(n - 2) + GetWays(n - 3);
		}

		/*******K-th Smallest in Lexicographical Order*********/

		public int FindKthNumber(int n, int k)
		{
			int curr = 1;
			k = k - 1;
			while (k > 0)
			{
				int steps = calSteps(n, curr, curr+1);
				if (steps <= k)
				{
					curr = curr + 1;
					k = k - steps;
				}
				else
				{
					curr = curr * 10;
					k = k - 1;
				}
			}
			return curr;
		}

		public int calSteps(int n, int n1, int n2)
		{
			int steps = 0;
			while (n1 <= n)
			{
				steps = steps + Math.Min(n + 1, n2) - n1;
				n1 = n1 * 10;
				n2 = n2 * 10;
			}
			return steps;
		}


		// Convert numbers to words
		String[] numberUnderTen = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
		String[] numberUnderTwenty = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
		String[] numberUnderHundred = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

		public string NumberToWords(int num)
		{
			string output = null;
			if (num == 0)
			{
				return "Zero";
			}
			else
			{
				output = helper(num);
			}
			return output;
		}

		private string helper(int num)
		{
			string output = null;
			if (num < 10)
			{
				output = numberUnderTen[num];
			}
			else if (num < 20)
			{
				output = numberUnderTwenty[num % 10];
			}
			else if (num < 100)
			{
				output = numberUnderHundred[num/10] + " " + helper(num % 10);
			}
			else if (num < 1000)
			{
				output = helper(num / 100) + " Hundred " + helper(num % 100);
			}
			else if (num < 1000000)
			{
				output = helper(num / 1000) + " Thousand " + helper(num % 1000);
			}
			else if (num < 1000000000)
			{
				output = helper(num / 1000000) + " Million " + helper(num % 1000000);
			}
			else
			{
				output = helper(num / 1000000000) + " Billion " + helper(num % 1000000000);
			}

			return output.Trim();
		}
	}
}
