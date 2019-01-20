
// Template Method pattern -- Real World example 

//-------------------------------------------------
//	This real-world code demonstrates a Template method named Run() which provides a 
//	skeleton calling sequence of methods. Implementation of these steps are deferred 
//	to the CustomerDataObject subclass which implements the Connect, Select, Process, 
//	and Disconnect methods. 
//
//	Output 
//	Categories ----
//	Beverages
//	Condiments
//	Confections
//	Dairy Products
//	Grains/Cereals
//	Meat/Poultry
//	Produce
//	Seafood
//
//	Products ----
//	Chai
//	Chang
//	Aniseed Syrup
//	Chef Anton's Cajun Seasoning
//	Chef Anton's Gumbo Mix
//	Grandma's Boysenberry Spread
//	Uncle Bob's Organic Dried Pears
//	Northwoods Cranberry Sauce
//	Mishi Kobe Niku
//-------------------------------------------------

using System;
using System.Data;
using System.Data.OleDb;

namespace DoFactory.GangOfFour.Template.RealWorld
{
  
	// MainApp test application 

	class MainApp
	{
		static void Main()
		{
			DataAccessObject dao;
      
			dao = new Categories();
			dao.Run();

			dao = new Products();
			dao.Run();

			// Wait for user 
			Console.Read();
		}
	}

	// "AbstractClass" 

	abstract class DataAccessObject
	{
		protected string connectionString;

		protected DataSet dataSet;

		public virtual void Connect()
		{
			// Make sure mdb is on c:\ 
			connectionString = 
				"provider=Microsoft.JET.OLEDB.4.0; " +
				"data source=c:\\nwind.mdb";
		}

		public abstract void Select();
		public abstract void Process();

		public virtual void Disconnect()
		{
			connectionString = "";
		}

		// The "Template Method" 

		public void Run()
		{
			Connect();
			Select();
			Process();
			Disconnect();
		}
	}

	// "ConcreteClass" 

	class Categories : DataAccessObject
	{
		public override void Select()
		{
			string sql = "select CategoryName from Categories";
			OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
				sql, connectionString);

			dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Categories");
		}

		public override void Process()
		{
			Console.WriteLine("Categories ---- ");
      
			DataTable dataTable = dataSet.Tables["Categories"];
			foreach (DataRow row in dataTable.Rows)
			{
				Console.WriteLine(row["CategoryName"]);
			}
			Console.WriteLine();
		}
	}

	class Products : DataAccessObject
	{
		public override void Select()
		{
			string sql = "select ProductName from Products";
			OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
				sql, connectionString);

			dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Products");
		}

		public override void Process()
		{
			Console.WriteLine("Products ---- ");
			DataTable dataTable = dataSet.Tables["Products"];
			foreach (DataRow row in dataTable.Rows)
			{
				Console.WriteLine(row["ProductName"]);
			}
			Console.WriteLine();
		}
	}
}

 
