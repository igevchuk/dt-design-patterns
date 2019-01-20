#region Comment
// State pattern -- Real World example 

//-------------------------------------------------
//	This real-world code demonstrates the State pattern which allows an Account to 
//	behave differently depending on its balance. The difference in behavior is delegated 
//	to State objects called RedState, SilverState and GoldState. These states represent 
//	overdrawn accounts, starter accounts, and accounts in good standing. 
//
//	Output 
//	Deposited $500.00 ---
//	Balance = $500.00
//	Status = SilverState
//
//
//	Deposited $300.00 ---
//	Balance = $800.00
//	Status = SilverState
//
//
//	Deposited $550.00 ---
//	Balance = $1,350.00
//	Status = GoldState
//
//
//	Interest Paid ---
//	Balance = $1,417.50
//	Status = GoldState
//
//	Withdrew $2,000.00 ---
//	Balance = ($582.50)
//	Status = RedState
//
//	No funds available for withdrawal!
//	Withdrew $1,100.00 ---
//	Balance = ($582.50)
//	Status = RedState
//-------------------------------------------------
#endregion

using System;

namespace DoFactory.GangOfFour.State.RealWorld
{
  
	// MainApp test application 

	class MainApp
	{
		static void Main()
		{
			// Open a new account 
			Account account = new Account("Jim Johnson");

			// Apply financial transactions 
			account.Deposit(500.0);
			account.Deposit(300.0);
			account.Deposit(550.0);
			account.PayInterest();
			account.Withdraw(2000.00);
			account.Withdraw(1100.00);

			// Wait for user 
			Console.Read();
		}
	}

	// "State" 

	abstract class State
	{
		protected Account account;
		protected double balance;

		protected double interest;
		protected double lowerLimit;
		protected double upperLimit;

		// Properties 
		public Account Account
		{
			get{ return account; }
			set{ account = value; }
		}

		public double Balance
		{
			get{ return balance; }
			set{ balance = value; }
		}

		public abstract void Deposit(double amount);
		public abstract void Withdraw(double amount);
		public abstract void PayInterest();
	}

	// "ConcreteState" 

	// Account is overdrawn 

	class RedState : State
	{
		double serviceFee;

		// Constructor 
		public RedState(State state)
		{
			this.balance = state.Balance;
			this.account = state.Account;
			Initialize();
		}

		private void Initialize()
		{
			// Should come from a datasource 
			interest = 0.0;
			lowerLimit = -100.0;
			upperLimit = 0.0;
			serviceFee = 15.00;
		}

		public override void Deposit(double amount)
		{
			balance += amount;
			StateChangeCheck();
		}

		public override void Withdraw(double amount)
		{
			amount = amount - serviceFee;
			Console.WriteLine("No funds available for withdrawal!");
		}

		public override void PayInterest()
		{
			// No interest is paid 
		}

		private void StateChangeCheck()
		{
			if (balance > upperLimit)
			{
				account.State = new SilverState(this);
			}
		}
	}

	// "ConcreteState" 

	// Silver is non-interest bearing state 

	class SilverState : State
	{
		// Overloaded constructors 

		public SilverState(State state) : 
			this( state.Balance, state.Account)
		{  
		}

		public SilverState(double balance, Account account)
		{
			this.balance = balance;
			this.account = account;
			Initialize();
		}

		private void Initialize()
		{
			// Should come from a datasource 
			interest = 0.0;
			lowerLimit = 0.0;
			upperLimit = 1000.0;
		}

		public override void Deposit(double amount)
		{
			balance += amount;
			StateChangeCheck();
		}

		public override void Withdraw(double amount)
		{
			balance -= amount;
			StateChangeCheck();
		}

		public override void PayInterest()
		{
			balance += interest * balance;
			StateChangeCheck();
		}

		private void StateChangeCheck()
		{
			if (balance < lowerLimit)
			{
				account.State = new RedState(this);
			}
			else if (balance > upperLimit)
			{
				account.State = new GoldState(this);
			}
		}
	}

	// "ConcreteState" 

	// Interest bearing state 

	class GoldState : State
	{
		// Overloaded constructors 
		public GoldState(State state) 
			: this(state.Balance,state.Account)
		{  
		}

		public GoldState(double balance, Account account)
		{
			this.balance = balance;
			this.account = account;
			Initialize();
		}

		private void Initialize()
		{
			// Should come from a database 
			interest = 0.05;
			lowerLimit = 1000.0;
			upperLimit = 10000000.0;
		}

		public override void Deposit(double amount)
		{
			balance += amount;
			StateChangeCheck();
		}

		public override void Withdraw(double amount)
		{
			balance -= amount;
			StateChangeCheck();
		}

		public override void PayInterest()
		{
			balance += interest * balance;
			StateChangeCheck();
		}

		private void StateChangeCheck()
		{
			if (balance < 0.0)
			{
				account.State = new RedState(this);
			}
			else if (balance < lowerLimit)
			{
				account.State = new SilverState(this);
			}
		}
	}

	// "Context" 

	class Account
	{
		private State state;
		private string owner;

		// Constructor 
		public Account(string owner)
		{
			// New accounts are 'Silver' by default 
			this.owner = owner;
			state = new SilverState(0.0, this);
		}

		// Properties 
		public double Balance
		{
			get{ return state.Balance; }
		}

		public State State
		{
			get{ return state; }
			set{ state = value; }
		}

		public void Deposit(double amount)
		{
			state.Deposit(amount);
			Console.WriteLine("Deposited {0:C} --- ", amount);
			Console.WriteLine(" Balance = {0:C}", this.Balance);
			Console.WriteLine(" Status = {0}\n" , this.State.GetType().Name);
			Console.WriteLine("");
		}

		public void Withdraw(double amount)
		{
			state.Withdraw(amount);
			Console.WriteLine("Withdrew {0:C} --- ", amount);
			Console.WriteLine(" Balance = {0:C}", this.Balance);
			Console.WriteLine(" Status = {0}\n" , this.State.GetType().Name);
		}

		public void PayInterest()
		{
			state.PayInterest();
			Console.WriteLine("Interest Paid --- ");
			Console.WriteLine(" Balance = {0:C}", this.Balance);
			Console.WriteLine(" Status = {0}\n" , this.State.GetType().Name);
		}
	}
}


 
