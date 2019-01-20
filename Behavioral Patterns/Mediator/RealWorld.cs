
// Mediator pattern -- Real World example 

//-------------------------------------------------
//	This real-world code demonstrates the Mediator pattern facilitating loosely 
//	coupled communication between different Participants registering with a Chatroom. 
//	The Chatroom is the central hub through which all communication takes place. 
//	At this point only one-to-one communication is implemented in the Chatroom, 
//	but would be trivial to change to one-to-many. 
//
//	Output 
//	To a Beatle: Yoko to John: 'Hi John!'
//	To a Beatle: Paul to Ringo: 'All you need is love'
//	To a Beatle: Ringo to George: 'My sweet Lord'
//	To a Beatle: Paul to John: 'Can't buy me love'
//	To a non-Beatle: John to Yoko: 'My sweet love'
//-------------------------------------------------

using System;
using System.Collections;

namespace DoFactory.GangOfFour.Mediator.RealWorld
{
  
	// MainApp test application 

	class MainApp
	{
		static void Main()
		{
			// Create chatroom 
			Chatroom chatroom = new Chatroom();

			// Create participants and register them 
			Participant George = new Beatle("George");
			Participant Paul = new Beatle("Paul");
			Participant Ringo = new Beatle("Ringo");
			Participant John = new Beatle("John") ;
			Participant Yoko = new NonBeatle("Yoko");

			chatroom.Register(George);
			chatroom.Register(Paul);
			chatroom.Register(Ringo);
			chatroom.Register(John);
			chatroom.Register(Yoko);

			// Chatting participants 
			Yoko.Send ("John", "Hi John!");
			Paul.Send ("Ringo", "All you need is love");
			Ringo.Send("George", "My sweet Lord");
			Paul.Send ("John", "Can't buy me love");
			John.Send ("Yoko", "My sweet love") ;

			// Wait for user 
			Console.Read();
		}
	}

	// "Mediator" 

	abstract class AbstractChatroom
	{
		public abstract void Register(Participant participant);
		public abstract void Send(string from, string to, string message);
	}

	// "ConcreteMediator" 

	class Chatroom : AbstractChatroom
	{
		private Hashtable participants = new Hashtable();

		public override void Register(Participant participant)
		{
			if (participants[participant.Name] == null)
			{
				participants[participant.Name] = participant;
			}

			participant.Chatroom = this;
		}

		public override void Send(string from, string to, string message)
		{
			Participant pto = (Participant)participants[to];
			if (pto != null)
			{
				pto.Receive(from, message);
			}
		}
	}

	// "AbstractColleague" 

	class Participant
	{
		private Chatroom chatroom;
		private string name;

		// Constructor 
		public Participant(string name)
		{
			this.name = name;
		}

		// Properties 
		public string Name
		{
			get{ return name; }
		}

		public Chatroom Chatroom
		{
			set{ chatroom = value; }
			get{ return chatroom; }
		}

		public void Send(string to, string message)
		{
			chatroom.Send(name, to, message);
		}

		public virtual void Receive(string from, string message)
		{
			Console.WriteLine("{0} to {1}: '{2}'",
				from, Name, message);
		}
	}

	//" ConcreteColleague1" 

	class Beatle : Participant
	{
		// Constructor 
		public Beatle(string name) : base(name) 
		{ 
		}

		public override void Receive(string from, string message)
		{
			Console.Write("To a Beatle: ");
			base.Receive(from, message);
		}
	}

	//" ConcreteColleague2" 

	class NonBeatle : Participant
	{
		// Constructor 
		public NonBeatle(string name) : base(name) 
		{ 
		}

		public override void Receive(string from, string message)
		{
			Console.Write("To a non-Beatle: ");
			base.Receive(from, message);
		}
	}
}

