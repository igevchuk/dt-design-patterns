
// Facade pattern -- Real World example 

//-------------------------------------------------
//	This real-world code demonstrates the Facade pattern as a MortgageApplication 
//	object which provides a simplified interface to a large subsystem of classes 
//	measuring the creditworthyness of an applicant. 
//
//	Output 
//	Ann McKinsey applies for $125,000.00 loan
//
//	Check bank for Ann McKinsey
//	Check loans for Ann McKinsey
//	Check credit for Ann McKinsey
//
//	Ann McKinsey has been Approved 
//-------------------------------------------------

using System;

namespace DoFactory.GangOfFour.Facade.RealWorld
{
	// MainApp test application 

	class MainApp
	{
		static void Main()
		{
			// Facade 
			Mortgage mortgage = new Mortgage();

			// Evaluate mortgage eligibility for customer 
			Customer customer = new Customer("Ann McKinsey");
			bool eligable = mortgage.IsEligible(customer,125000);
      
			Console.WriteLine("\n" + customer.Name + 
				" has been " + (eligable ? "Approved" : "Rejected"));

			// Wait for user 
			Console.Read();
		}
	}

	// "Subsystem ClassA" 

	class Bank
	{
		public bool HasSufficientSavings(Customer c, int amount)
		{
			Console.WriteLine("Check bank for " + c.Name);
			return true;
		}
	}

	// "Subsystem ClassB" 

	class Credit
	{
		public bool HasGoodCredit(Customer c)
		{
			Console.WriteLine("Check credit for " + c.Name);
			return true;
		}
	}

	// "Subsystem ClassC" 

	class Loan
	{
		public bool HasNoBadLoans(Customer c)
		{
			Console.WriteLine("Check loans for " + c.Name);
			return true;
		}
	}

	class Customer
	{
		private string name;

		// Constructor 
		public Customer(string name)
		{
			this.name = name;
		}

		// Property 
		public string Name
		{
			get{ return name; }
		}
	}

	// "Facade" 

	class Mortgage
	{
		private Bank bank = new Bank();
		private Loan loan = new Loan();
		private Credit credit = new Credit();

		public bool IsEligible(Customer cust, int amount)
		{
			Console.WriteLine("{0} applies for {1:C} loan\n", cust.Name, amount);

			bool eligible = true;

			// Check creditworthyness of applicant 
			if (!bank.HasSufficientSavings(cust, amount)) 
			{
				eligible = false;
			}
			else if (!loan.HasNoBadLoans(cust)) 
			{
				eligible = false;
			}
			else if (!credit.HasGoodCredit(cust)) 
			{
				eligible = false;
			}

			return eligible;
		}
	}
}