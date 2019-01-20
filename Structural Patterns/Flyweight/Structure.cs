
// Flyweight pattern -- Structural example 

//-------------------------------------------------
//	This structural code demonstrates the Flyweight pattern in which a relatively 
//	small number of objects is shared many times by different clients. 
//
//	Output 
//	ConcreteFlyweight: 21
//	ConcreteFlyweight: 20
//	ConcreteFlyweight: 19
//	UnsharedConcreteFlyweight: 18
//-------------------------------------------------

using System;
using System.Collections;

namespace DoFactory.GangOfFour.Flyweight.Structural
{
	// MainApp test application 

	class MainApp
	{
		static void Main()
		{
			// Arbitrary extrinsic state 
			int extrinsicstate = 22;
    
			FlyweightFactory f = new FlyweightFactory();

			// Work with different flyweight instances 
			Flyweight fx = f.GetFlyweight("X");
			fx.Operation(--extrinsicstate);

			Flyweight fy = f.GetFlyweight("Y");
			fy.Operation(--extrinsicstate);

			Flyweight fz = f.GetFlyweight("Z");
			fz.Operation(--extrinsicstate);

			UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();

			fu.Operation(--extrinsicstate);

			// Wait for user 
			Console.Read();
		}
	}

	// "FlyweightFactory" 

	class FlyweightFactory 
	{
		private Hashtable flyweights = new Hashtable();

		// Constructor 
		public FlyweightFactory()
		{
			flyweights.Add("X", new ConcreteFlyweight());    
			flyweights.Add("Y", new ConcreteFlyweight());
			flyweights.Add("Z", new ConcreteFlyweight());
		}

		public Flyweight GetFlyweight(string key)
		{
			return((Flyweight)flyweights[key]); 
		}
	}

	// "Flyweight" 

	abstract class Flyweight 
	{
		public abstract void Operation(int extrinsicstate);
	}

	// "ConcreteFlyweight" 

	class ConcreteFlyweight : Flyweight
	{
		public override void Operation(int extrinsicstate)
		{
			Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
		}
	}

	// "UnsharedConcreteFlyweight" 

	class UnsharedConcreteFlyweight : Flyweight
	{
		public override void Operation(int extrinsicstate)
		{
			Console.WriteLine("UnsharedConcreteFlyweight: " + extrinsicstate);
		}
	}
}

 




