using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTDD
{
	class Program
	{
		static void Main(string[] args)
		{
			MathOperations m = new MathOperations();

			int output = m.AddTwoNumbers(5, 4);

			Console.WriteLine(output);

			Console.ReadKey();
		}
	}
}
