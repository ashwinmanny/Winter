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

		public double MyPow(double x, int n)
		{
			double value = 0;
			var sign = n > 0;
			value = MyPowByDD(x, n);

			return sign ? value : 1 / value;
		}

		public double MyPowByDD(double x, int n)
		{
			double value = 0;
			if (n == 0)
			{
				return 1;
			}
			else if (n == 1)
			{
				return x;
			}
			else
			{
				if (n % 2 == 0)
				{
					value = MyPowByDD(x * x, n / 2);
				}
				else
				{
					value = x * MyPowByDD(x * x, n / 2);
				}

			}

			return value;
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

		private List<string> strlist = new List<string>();
		public IList<string> GenerateParenthesis(int n)
		{
			GenerateParenthesisHelper(n, n, string.Empty);
			return strlist;
		}

		private void GenerateParenthesisHelper(int left, int right, string result)
		{
			if (left == 0 && right == 0)
			{
				strlist.Add(result);
				return;
			}

			if (left > 0)
			{
				GenerateParenthesisHelper(left - 1, right, result + '(');
			}

			if (right > left)
			{
				GenerateParenthesisHelper(left, right - 1, result + ')');
			}
		}

		public IList<IList<int>> GetFactors(int n)
		{
			IList<int> temp = new List<int>();
			IList<IList<int>> result = new List<IList<int>>();
			if (n < 4) return result;
			Helper(n, 2, temp, result, n);
			return result;
		}

		public static void Helper(int n, int factor, IList<int> temp, IList<IList<int>> result, int ori)
		{
			int sqrt = Convert.ToInt32(Math.Floor(Math.Sqrt(n)));
			if (factor > n) return;
			if (n != ori)
			{
				IList<int> temp1 = new List<int>(temp);
				temp1.Add(n);
				result.Add(temp1);
			}
			for (int i = factor; i <= sqrt; i++)
			{
				if (n % i == 0)
				{
					IList<int> temp2 = new List<int>(temp);
					temp2.Add(i);
					Helper(n / i, i, temp2, result, ori);
				}
			}
		}

		/**More efficient but requires proper java to c# translation
		 
			public static List<List<int>> getFactors(int n)
			{
				List<List<int>> res = new List<List<int>>();

				helper(res, new List<int>(), 2, n);
				return res;
			}

			public static void helper(List<List<int>> res, List<int> list, int s, int n)
			{
				for (int i = s; i <= Math.Sqrt(n); i++)
				{
					int x = n / i;
					if (n % i == 0)
					{
						list.Add(i);
						list.Add(x);
						res.Add(new List<int>(list));
						list.Remove(list.Count - 1);
						helper(res, list, i, x);
						list.Remove(list.Count - 1);
					}
				}
			}
		 */

		Dictionary<char, String> map = new Dictionary<char, String>();
		public bool WordPattern2(String pattern, String str)
		{
			if (pattern.Length == 0)
				return str.Length == 0;

			if (map.ContainsKey(pattern[0]))
			{
				String value = map[pattern[0]];
				if (value.Length > str.Length || !str.Substring(0, value.Length).Equals(value))
					return false;
				if (WordPattern2(pattern.Substring(1), str.Substring(value.Length)))
					return true;
			}
			else
			{
				for (int i = 1; i <= str.Length; i++)
				{
					if (map.ContainsValue(str.Substring(0, i))) continue;
					map.Add(pattern[0], str.Substring(0, i));
					if (WordPattern2(pattern.Substring(1), str.Substring(i)))
					{
						return true;
					}
					map.Remove(pattern[0]);
				}
			}
			return false;
		}
	}
}
