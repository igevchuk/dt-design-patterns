
// Strategy pattern -- Structural example 

//-------------------------------------------------
//	This structural code demonstrates the Strategy pattern which encapsulates 
//	functionality in the form of an object. This allows clients to dynamically change 
//	algorithmic strategies. 
//
//	Output 
//	Called ConcreteStrategyA.AlgorithmInterface()
//	Called ConcreteStrategyB.AlgorithmInterface()
//	Called ConcreteStrategyC.AlgorithmInterface()
//-------------------------------------------------

using System;

namespace DoFactory.GangOfFour.Strategy.Structural
{
  
	// MainApp test application 

	class MainApp
	{
		static void Main()
		{
			Context context;

			// Three contexts following different strategies 
			context = new Context(new ConcreteStrategyA());
			context.ContextInterface();

			context = new Context(new ConcreteStrategyB());
			context.ContextInterface();

			context = new Context(new ConcreteStrategyC());
			context.ContextInterface();

			// Wait for user 
			Console.Read();
		}
	}

	// "Strategy" 

	abstract class Strategy
	{
		public abstract void AlgorithmInterface();
	}

	// "ConcreteStrategyA" 

	class ConcreteStrategyA : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
		}
	}

	// "ConcreteStrategyB" 

	class ConcreteStrategyB : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
		}
	}

	// "ConcreteStrategyC" 

	class ConcreteStrategyC : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
		}
	}

	// "Context" 

	class Context
	{
		Strategy strategy;

		// Constructor 
		public Context(Strategy strategy)
		{
			this.strategy = strategy;
		}

		public void ContextInterface()
		{
			strategy.AlgorithmInterface();
		}
	}
}



 


