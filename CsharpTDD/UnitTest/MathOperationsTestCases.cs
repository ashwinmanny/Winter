using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsharpTDD.UnitTest
{
	[TestClass]
	class MathOperationsTestCases
	{

		public MathOperationsTestCases()
		{
		}

		[TestMethod]
		public void AddTwoNumbersTestCase()
		{
			int a = 5;
			int b = 4;
			int c = a + b;
			int output = 9;

			Assert.Equals(output, c);
		}
	}
}
