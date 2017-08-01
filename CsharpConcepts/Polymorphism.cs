using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts
{
	class Polymorphism
	{
	}

	class ClassA
	{
		public int id;
		public string name;

		public ClassA()
		{
		}

		public void PrintDetails(string methodType)
		{
			Console.WriteLine(" ");
			Console.WriteLine(methodType);
			Console.WriteLine(id);
			Console.WriteLine(name);
		}

		public virtual void PrintDetails()
		{
			Console.WriteLine(" ");
			Console.WriteLine(id);
			Console.WriteLine(name);
		}

	}

	class ClassB : ClassA
	{
		public int salary { get; set; }

		public override void PrintDetails()
		{
			Console.WriteLine(" ");
			Console.WriteLine(salary);
		}

	}
}
