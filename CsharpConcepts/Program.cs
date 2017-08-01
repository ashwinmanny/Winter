using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts
{
	class Program
	{
		public delegate void Transform(int x);

		static void Main(string[] args)
		{
			ClassA cA = new ClassA();

			cA.id = 12;
			cA.name = "Ash";

			cA.PrintDetails();
			//Overloading - compile time polymorphism
			cA.PrintDetails("Overloaded Method");

			//Overriding - runtime polymorphism
			cA = new ClassB();	
			cA.PrintDetails();

			//Using delegates 1
			InheritanceA iA1 = new InheritanceA();
			Transform t1 = iA1.Sqrt; 
			t1 = t1 + iA1.Cube; //multicast delegate
			t1(5);

			//Using delegates 2
			InheritanceA iA2 = new InheritanceA();
			InheritanceB iB2 = new InheritanceB();

			iA2.Transform(8, iB2.FourTime);

			//Using anonymous function


			t1 = delegate(int x)
			{
				Console.WriteLine("Anonymous: 10 times {0}", x * 10);
			};

			t1(7);

			//Using lambda expression

			t1 = (int x) => { Console.WriteLine("Lambda: 10 times {0}", x * 10);};

			t1(8);

			Console.ReadKey();
		}

	}

}
