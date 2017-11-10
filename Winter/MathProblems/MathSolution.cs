using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.MathProblems
{
	class MathSolution
	{

		public int MyAtoi(string str)
		{
			long res = 0;
			var sign = 1;
			str = str.Trim();
			if (string.IsNullOrEmpty(str)) return 0;
			var index = 0;
			if (str[0] == '+' || str[0] == '-')
			{
				sign = str[0] == '+' ? 1 : -1;
				index++;
			}
			while (index < str.Length)
			{
				if (!char.IsNumber(str[index]))
				{
					break;
				}
				res = res * 10 + str[index] - '0';
				if (res * sign > int.MaxValue) return int.MaxValue;
				if (res * sign < int.MinValue) return int.MinValue;
				index++;
			}

			/*Requirements for atoi:
				The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

				The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

				If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

				If no valid conversion could be performed, a zero value is returned. If the correct value is out of the range of representable values, INT_MAX (2147483647) or INT_MIN (-2147483648) is returned.*/

			return (int)res * sign;
		}

		public decimal EvaluateMathExpression(string input)
		{
			// sample input expression: 15 + 2 -3

			//operators dictionary with precedence
			Dictionary<char, int> operators = new Dictionary<char, int>
			{
				   {'+', 1}, {'-', 1}, {'*', 2}, {'/', 3}
			};

			List<string> elements = TokenizeExpression(input, operators);

			decimal value = 0;

			for (int i = operators.Values.Max(); i >= operators.Values.Min(); i--)
			{

				while (elements.Count >= 3
					&& elements.Any(element => element.Length == 1 &&
						operators.Where(op => op.Value == i)
						.Select(op => op.Key).Contains(element[0])))
				{
					int pos = elements
						.FindIndex(element => element.Length == 1 &&
						operators.Where(op => op.Value == i)
						.Select(op => op.Key).Contains(element[0]));

					value = EvaluateOperation(elements[pos],
						elements[pos - 1], elements[pos + 1]);

					elements[pos - 1] = value.ToString();

					elements.RemoveRange(pos, 2);
				}
			}

			return value;
		}

		private static List<string> TokenizeExpression
			(string expression, Dictionary<char, int> operators)
		{
			List<string> elements = new List<string>();
			string currentElement = string.Empty;
			for (int i = 0; i < expression.Length; i++)
			{
				if (operators.Keys.Contains(expression[i]))
				{
					//The current character is an operator
					elements.Add(currentElement);
					elements.Add(expression[i].ToString());
					currentElement = string.Empty;
				}
				else if (expression[i] != ' ')
				{
					//The current character is neither an operator nor a space
					currentElement += expression[i];
				}
			}

			//Add the last element to the list
			if (currentElement.Length > 0)
			{
				elements.Add(currentElement);
			}

			return elements;
		}

		private static decimal EvaluateOperation(string oper, string operand1, string operand2)
		{
			try
			{
				decimal op1 = Convert.ToDecimal(operand1);
				decimal op2 = Convert.ToDecimal(operand2);

				if (oper.Length == 1)
				{
					decimal value = 0;
					switch (oper[0])
					{
						case '+':
							value = op1 + op2;
							break;
						case '-':
							value = op1 - op2;
							break;
						case '*':
							value = op1 * op2;
							break;
						case '/':
							value = op1 / op2;
							break;
						default:
							throw new ArgumentException("Unsupported operator");
					}
					return value;
				}
				else
				{
					throw new ArgumentException("Unsupported operator");
				}
			}
			catch(Exception e)
			{
				throw new ArgumentException("Invalid input"+e.Message);
			}
		}

		public int MaxPoints(Point[] points)
		{
			var max = 0;
			foreach (var point in points)
			{
				var hashtable = new Dictionary<double, int>();
				var samePointNumber = 0;
				foreach (var anotherPoint in points)
				{
					if (point.x == anotherPoint.x && point.y == anotherPoint.y)
					{
						samePointNumber++;
						continue;
					}
					var k = (point.y - anotherPoint.y) * 1.0 / (point.x - anotherPoint.x);
					if (hashtable.ContainsKey(k))
					{
						hashtable[k]++;
					}
					else
					{
						hashtable.Add(k, 1);
					}
				}

				max = Math.Max(max, samePointNumber);
				max = hashtable.Values.Select(value => value + samePointNumber).Concat(new[] { max }).Max();
			}

			return max;
		}

		public int MinDistance(int height, int width, int[] tree, int[] squirrel, int[,] nuts)
		{
			int sum = 0, maxDiff = int.MinValue;

			for (int i = 0; i < nuts.GetLength(0); i++)
			{
				int dist = Math.Abs(tree[0] - nuts[i,0]) + Math.Abs(tree[1] - nuts[i,1]);// distance fron nut to tree
				sum = sum + 2 * dist;// back and forth doubles the distance
				maxDiff = Math.Max(maxDiff, dist - Math.Abs(squirrel[0] - nuts[i, 0]) - Math.Abs(squirrel[1] - nuts[i, 1]));//first visited nut, the saving obtained
			}

			return sum - maxDiff;
		}
	}
}
