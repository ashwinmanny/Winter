using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts
{
	public delegate void Transformer(int x);

	abstract class Inheritance
	{
		public int id;
		public string name;

		public Inheritance()
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

	class InheritanceA : Inheritance
	{
		public InheritanceA()
		{
		}

		public new void PrintDetails(string methodType)
		{
			Console.WriteLine(" ");
			Console.WriteLine(methodType);
			Console.WriteLine(id);
			Console.WriteLine(name);
		}

		public override void PrintDetails()
		{
			Console.WriteLine(" ");
			Console.WriteLine(id);
			Console.WriteLine(name);
		}

		public void PrintDummyDetails()
		{
			Console.WriteLine(" ");
			Console.WriteLine("1");
			Console.WriteLine("Testing");
		}

		public void Sqrt(int x)
		{
			Console.WriteLine("Square is {0}", x * x);
			//return x * x;
		}

		public void Cube(int x)
		{
			Console.WriteLine("Cube is {0}", x * x * x);
			//return x * x;
		}

		public void Transform(int x, Transformer t)
		{
			t(x);
		}

	}

	interface IInheritance
	{
		int Id {get; set;}
		string Name {get; set;}


		void PrintDetails(string methodType);

		void PrintDetails();
	}

	class InheritanceB : IInheritance
	{
		int id;
		string name;

		public int Id { get { return id; } set { this.id = value; } }
		public string Name { get { return name; } set { this.name = value; } }

		public InheritanceB()
		{
		}

		public void PrintDetails(string methodType)
		{
			Console.WriteLine(" ");
			Console.WriteLine(methodType);
			Console.WriteLine(id);
			Console.WriteLine(name);
		}

		public void PrintDetails()
		{
			Console.WriteLine(" ");
			Console.WriteLine(id);
			Console.WriteLine(name);
		}

		public void FourTime(int x)
		{
			Console.WriteLine("Four times {0}", x * x * x * x);
		}
	}


}
