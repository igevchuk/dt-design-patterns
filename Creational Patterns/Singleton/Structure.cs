
// Singleton pattern -- Structural example 

//-------------------------------------------------
//	This structural code demonstrates the Singleton pattern which assures only a 
//	single instance (the singleton) of the class can be created. 
//
//	Output 
//	Objects are the same instance 
//-------------------------------------------------

using System;

namespace DoFactory.GangOfFour.Singleton.Structural
{
  
	// MainApp test application 

	class MainApp
	{
    
		static void Main()
		{
			// Constructor is protected -- cannot use new 
			Singleton s1 = Singleton.Instance();
			Singleton s2 = Singleton.Instance();

			if (s1 == s2)
			{
				Console.WriteLine("Objects are the same instance");
			}

			// Wait for user 
			Console.Read();
		}
	}

	// "Singleton" 

	class Singleton
	{
		private static Singleton instance;

		// Note: Constructor is 'protected' 
		protected Singleton() 
		{
		}

		public static Singleton Instance()
		{
			// Use 'Lazy initialization' 
			if (instance == null)
			{
				instance = new Singleton();
			}

			return instance;
		}
	}
}





