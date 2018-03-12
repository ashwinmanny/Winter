using System;
using CsharpConcepts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCsharpOOConcepts
{
	[TestClass]
	public class UnitTestDesignPattern
	{
		[TestMethod]
		public void TestMethodSingletonPattern()
		{
			Assert.AreSame(Singleton.GetInstance, Singleton.GetInstance);
		}
	}
}
