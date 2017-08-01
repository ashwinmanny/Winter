using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerR
{
	class CalculatorNew
	{
		public int power(int n, int p)
		{
			int answer;

			if (n < 0 || p < 0)
			{
				throw new Exception("n and p should be non-negative");
			}
			else
			{
				answer = Convert.ToInt32(Math.Pow(n, p));
			}


			return answer;
		}
	}
}
