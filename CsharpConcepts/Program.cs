using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

			//Factory Method

			VehicleFactory veh = new MotorBikeFactory();
			IVehicle v = veh.CreateVehicle();
			Console.WriteLine(v.VersionId);
			v.Type();
			v.WheelCount();

			//Abstract Factory Pattern

			WineFactory american = new AmericanWineFactory();
			WineShop shop = new WineShop(american);
			shop.PrintList();
			
			WineFactory european = new EuropeanWineFactory();
			shop = new WineShop(european);
			shop.PrintList();

			//Multithreading: Threads

			Console.WriteLine("Thread concepts");

			Thread t0 = new Thread(iA1.PrintDummyDetails); //thread parameter should have void return and no argument if passed using simple class object method
			Thread t2 = new Thread(() => {iA1.Sqrt(5);});//() is for lamda expression with no argument
			Thread t3 = new Thread(delegate() { iA1.Sqrt(5); });

			ThreadStart td = delegate() {iA1.Sqrt(5);};
			Thread t4 = new Thread(td);

			Thread t5 = new Thread(new ThreadStart(delegate() { iA1.Sqrt(5); }));

			t0.Start();
			t2.Start();
			t3.Start();
			t4.Start();
			t5.Start();

			Thread.Sleep(1); // Put the main thread to sleep for 1 millisecond to allow the worker thread to do some work

			t0.Join(); // Use the Join method to block the current thread  until the object's thread terminates

			//Multithreading: ThreadPool

			ThreadPool.QueueUserWorkItem(delegate { Console.WriteLine("HELLO WORLD"); }); // anonymous delegate

			ThreadPool.QueueUserWorkItem(MyWork, "testing thread pool 1");//this won't work if method parameter type is not 'object'

			ThreadPool.QueueUserWorkItem(del => MyWork("testing thread pool 2"));

			ThreadPool.QueueUserWorkItem(new WaitCallback(del => MyWork("testing thread pool 3")));

			ThreadPool.QueueUserWorkItem(new WaitCallback(MyWork), "testing thread pool 4");

			//Multithreading: Task

			Task task1 = Task.Run(() => { iA1.Sqrt(5); });
			Task task2 = Task.Factory.StartNew(() => { iA1.Sqrt(5); });

			Console.ReadKey();
		}

		public static void MyWork(object argument)
		{
			Console.WriteLine("Argument: " + argument);
		}

	}

}
