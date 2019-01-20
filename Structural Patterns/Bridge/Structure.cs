
// Bridge pattern -- Structural example 

//-------------------------------------------------
//	This structural code demonstrates the Bridge pattern which separates 
//	(decouples) the interface from its implementation. The implementation can 
//	evolve without changing clients which use the abstraction of the object.
//
//	Output 
//	ConcreteImplementorA Operation
//	ConcreteImplementorB Operation
//-------------------------------------------------

using System;

namespace DoFactory.GangOfFour.Bridge.Structural
{

	// MainApp test application 

	class MainApp
	{
		static void Main()
		{
			Abstraction ab = new RefinedAbstraction();

			// Set implementation and call 
			ab.Implementor = new ConcreteImplementorA();
			ab.Operation();

			// Change implemention and call 
			ab.Implementor = new ConcreteImplementorB();
			ab.Operation();

			// Wait for user 
			Console.Read();
		}
	}

	// "Abstraction" 

	class Abstraction
	{
		protected Implementor implementor;

		// Property 
		public Implementor Implementor
		{
			set{ implementor = value; }
		}

		public virtual void Operation()
		{
			implementor.Operation();
		}
	}

	// "RefinedAbstraction" 

	class RefinedAbstraction : Abstraction
	{
		public override void Operation()
		{
			implementor.Operation();
		}
	}

	// "Implementor" 

	abstract class Implementor
	{
		public abstract void Operation();
	}

	// "ConcreteImplementorA" 

	class ConcreteImplementorA : Implementor
	{
		public override void Operation()
		{
			Console.WriteLine("ConcreteImplementorA Operation");
		}
	}

	// "ConcreteImplementorB" 

	class ConcreteImplementorB : Implementor
	{
		public override void Operation()
		{
			Console.WriteLine("ConcreteImplementorB Operation");
		}
	}
}


 

