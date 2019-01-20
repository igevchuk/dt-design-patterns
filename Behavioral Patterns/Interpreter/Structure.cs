
// Interpreter pattern -- Structural example 

//-------------------------------------------------
//	This structural code demonstrates the Interpreter patterns, which using a 
//	defined grammer, provides the interpreter that processes parsed statements.
//
//	Output 
//	Called Terminal.Interpret()
//	Called Nonterminal.Interpret()
//	Called Terminal.Interpret()
//	Called Terminal.Interpret()
//-------------------------------------------------

using System;
using System.Collections;

namespace DoFactory.GangOfFour.Interpreter.Structural
{
  
	// MainApp test application 

	class MainApp
	{
		static void Main()
		{
			Context context = new Context();

			// Usually a tree 
			ArrayList list = new ArrayList(); 

			// Populate 'abstract syntax tree' 
			list.Add(new TerminalExpression());
			list.Add(new NonterminalExpression());
			list.Add(new TerminalExpression());
			list.Add(new TerminalExpression());

			// Interpret 
			foreach (AbstractExpression exp in list)
			{
				exp.Interpret(context);
			}

			// Wait for user 
			Console.Read();
		}
	}

	// "Context" 

	class Context 
	{
	}

	// "AbstractExpression" 

	abstract class AbstractExpression 
	{
		public abstract void Interpret(Context context);
	}

	// "TerminalExpression" 

	class TerminalExpression : AbstractExpression
	{
		public override void Interpret(Context context)  
		{
			Console.WriteLine("Called Terminal.Interpret()");
		}
	}

	// "NonterminalExpression" 

	class NonterminalExpression : AbstractExpression
	{
		public override void Interpret(Context context)  
		{
			Console.WriteLine("Called Nonterminal.Interpret()");
		}  
	}
}



 
