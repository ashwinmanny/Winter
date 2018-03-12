using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts
{
	class DesignPattern
	{
	}

	/// <summary>
	/// Singleton Example
	/// </summary>

	public class Singleton
	{
		private static readonly Singleton instance = new Singleton();

		private Singleton() { }

		public static Singleton GetInstance()
		{
			return instance;
		}

	}
	/// <summary>
	/// Factory Method Example
	/// </summary>
	
	public interface IVehicle
	{
	    int VersionId { get; set; }

		void Type();

		void WheelCount();
	}

	public class Car: IVehicle
	{
		public int versionId;
		public int VersionId
		{
			get
			{
				return 0;
			}
			set
			{
				this.versionId = value;
			}
		}

		public void Type()
		{
			Console.WriteLine("Type: Car");
		}

		public void WheelCount()
		{
			Console.WriteLine("Wheel Count: 4");
		}
		
		public void FuelType()
		{
			Console.WriteLine("Fuel Type: Gas/Electric");
		}
	}

	public class MotorBike : IVehicle
	{
		public int VersionId { get; set; }

		public void Type()
		{
			Console.WriteLine("Type: Motor Bike");
		}

		public void WheelCount()
		{
			Console.WriteLine("Wheel Count: 2");
		}
	}

	public class BiCycle : IVehicle
	{
		public int VersionId { get; set; }

		public void Type()
		{
			Console.WriteLine("Type: Bicyle");
		}

		public void WheelCount()
		{
			Console.WriteLine("Wheel Count: 2");
		}

	}

	public abstract class VehicleFactory
	{
		public abstract IVehicle CreateVehicle(); //factory method
	}

	public class CarFactory : VehicleFactory
	{
		public IVehicle vehicle;
		public override IVehicle CreateVehicle()
		{
			vehicle = new Car();
			vehicle.VersionId = 10;
			return vehicle;
		}
	}

	public class MotorBikeFactory : VehicleFactory
	{
		public IVehicle vehicle;
		public override IVehicle CreateVehicle()
		{
			vehicle = new MotorBike();
			vehicle.VersionId = 11;
			return vehicle;
		}
	}

	public class BiCycleFactory : VehicleFactory
	{
		public IVehicle vehicle;
		public override IVehicle CreateVehicle()
		{
			vehicle = new BiCycle();
			vehicle.VersionId = 12;
			return vehicle;
		}
	}

	/// <summary>
	/// Abstract Factory Example
	/// </summary>
	/// 

	public abstract class Whiskey 
	{
		public abstract void AlcoholContent();
	}

	public abstract class Beer
	{
		public abstract void Size();
	}

	public class JohnnyWalker : Whiskey
	{
		public override void AlcoholContent()
		{
			Console.WriteLine("Alcohol Content: 12%");
		}
	}

	public class JackDaniels : Whiskey
	{
		public override void AlcoholContent()
		{
			Console.WriteLine("Alcohol Content: 10%");
		}
	}

	public class StellaArtois : Beer
	{
		public override void Size()
		{
			Console.WriteLine("Size: 12 oz");
		}
	}

	public class Budweiser : Beer
	{
		public override void Size()
		{
			Console.WriteLine("Size: 16 oz");
		}
	}

	abstract public class WineFactory
	{
		public abstract Whiskey CreateWhiskey();
		public abstract Beer CreateBeer();
	}

	public class AmericanWineFactory: WineFactory
	{
		public override Whiskey CreateWhiskey()
		{
			return new JohnnyWalker(); 
		}
		public override Beer CreateBeer()
		{
			return new StellaArtois();
		}

	}

	public class EuropeanWineFactory : WineFactory
	{
		public override Whiskey CreateWhiskey()
		{
			return new JackDaniels();
		}
		public override Beer CreateBeer()
		{
			return new Budweiser();
		}
	}

	public class WineShop
	{
		private Whiskey whiskey;
		private Beer beer;

		public WineShop(WineFactory winefactory)
		{
			whiskey = winefactory.CreateWhiskey();
			beer = winefactory.CreateBeer();
		}

		public void PrintList()
		{
			whiskey.AlcoholContent();
			beer.Size();
		}

	}
}
