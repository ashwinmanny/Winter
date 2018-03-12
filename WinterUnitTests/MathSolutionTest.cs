using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winter.MathProblems;

namespace WinterUnitTests
{
	[TestClass]
	public class MathSolutionTest
	{
		[TestMethod]
		public void TestMethodAtoi()
		{
			MathSolution m = new MathSolution();
			int output = m.MyAtoi("-0.3");

			Assert.AreEqual(0, output);
		}
	}

	/* for NUnit
	 * 
	[TestFixture]
	public class MathSolutionTest
	{
	    MathSolution m;
	 
        [TestFixtureSetUp]
        public void Initialize()
        {
            m = new MathSolution();
        }
	 
		[Test]
		public void TestMethodAtoi()
		{
			int output = m.MyAtoi("-0.3");

			Assert.That(output, Is.EqualTo(output));
		}
	}
	 */
}
