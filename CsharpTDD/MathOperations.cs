using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTDD
{
	class MathOperations
	{
		string operationType { get; set; }
		int operand1 { get; set; }
		int operand2 { get; set; }

		public MathOperations()
		{
			this.operationType = "Add";
		}

		public int AddTwoNumbers(int op1, int op2)
		{
			int output = op1 + op2;
			return output;
		}

	}
}
