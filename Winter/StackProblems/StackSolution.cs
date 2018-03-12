using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.StackProblems
{
	public class StackSolution
	{
		public int LargestRectangleArea(int[] heights)
		{
			Stack<int> stack = new Stack<int>();

			int max_area = 0;
			int tp;
			int area_with_top;
			int i = 0;

			while (i < heights.Length)
			{
				if (stack.Count == 0 || heights[i] > heights[stack.Peek()])
				{
					stack.Push(i);
					i++;
				}
				else
				{
					tp = stack.Peek();

					stack.Pop();

					//calculate area based on current index and index of previous smaller element in stack
					area_with_top = heights[tp] * (stack.Count == 0 ? i : i - stack.Peek() - 1);

					if (max_area < area_with_top)
					{
						max_area = area_with_top;
					}

				}
			}

			while(stack.Count != 0)
			{
				tp = stack.Peek();

				stack.Pop();

				area_with_top = heights[tp] * (stack.Count == 0 ? (i-1) : (i-1) - stack.Peek() - 1);

				if (max_area < area_with_top)
				{
					max_area = area_with_top;
				}

			}

			return max_area;
		}

		public static int EvalRPN(string[] tokens)
		{
			Stack<int> stack = new Stack<int>();

			for (int i = 0; i < tokens.Length; i++)
			{
				switch (tokens[i])
				{
					case "+":
						stack.Push(stack.Pop() + stack.Pop());
						break;

					case "-":
						stack.Push(-stack.Pop() + stack.Pop());
						break;

					case "*":
						stack.Push(stack.Pop() * stack.Pop());
						break;

					case "/":
						int n1 = stack.Pop(), n2 = stack.Pop();
						stack.Push(n2 / n1);
						break;

					default:
						stack.Push(Convert.ToInt32(tokens[i]));
						break;
				}
			}

			return stack.Pop();
		}
	}
}
