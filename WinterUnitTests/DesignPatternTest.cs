using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpConcepts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinterUnitTests
{
	[TestClass]
	public class DesignPatternTest
	{
		[TestMethod]
		public void TestMethodSingletonPattern()
		{
			Assert.AreSame(Singleton.GetInstance(), Singleton.GetInstance());
		}

	}
}
