
namespace SupportBank;
using NLog;
using Newtonsoft.Json;

public class DataReader
{
	private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
	public  PersonalAccount ReadTransactionData(string path) //provide path for specific cvs data file
	{
		List<AccountUser> usersList = new List<AccountUser>();
		List<Transaction> allTransactions = new List<Transaction>();

		string[] lines = System.IO.File.ReadAllLines(path);

		int rowCounter = 1;

		foreach (string line in lines.Skip(1)) // skit 1st line as column headers
		{
			rowCounter++;
			string[] fields = line.Split(','); //creates an array of fields, the different pieces of info in a line

			DateTime date = new DateTime(); // default?? why are we creating another date instance? wouldnt this create a new current date object whe run?
			try
			{
				date = DateTime.Parse(fields[0]);
			}
			catch (System.FormatException exception)
			{
				Logger.Error($"Error on row {rowCounter}. The date provided is not in the correct format");
				Console.WriteLine($"Error on row {rowCounter}. The date provided is not in the correct format");
				throw exception;
			}

			AccountUser ToUser = new AccountUser(Convert.ToString(fields[1])); // why conver to string? move from type Account user to type string

			AccountUser FromUser = new AccountUser(Convert.ToString(fields[2]));

			string details = fields[3];

			decimal amount;
			try
			{
				amount = decimal.Parse(fields[4]);
			}
			catch(System.FormatException exception)
			{	Logger.Error($"Error on row {rowCounter}. The amount has not been provided is the correct format");
				Console.WriteLine($"Error on row {rowCounter}. The amount must be entered as a decimal number");
				throw exception;
			}

			Transaction uniqueTransaction = new Transaction(date, ToUser, FromUser, details, amount);
			allTransactions.Add(uniqueTransaction);

			//Example of a Transaction: [Date, {Name: (string) name }, {Name:name}, Narrative, Amount  ]

			if (!usersList.Any(a => a.Name == uniqueTransaction.To.Name))
				usersList.Add(uniqueTransaction.To);

			//Example of UsersList: [{Name: name}, {Name: name}, {Name: name}]

		}
			Logger.Info($"All data in file {path} read correctly");
			return new PersonalAccount (usersList, allTransactions);
	}

	public void ReadJSONTransactionData(string path)
	{
		string lines = System.IO.File.ReadAllText(path);
		
			var jsonData = JsonConvert.DeserializeObject<List<TransactionJSON>>(lines);
			foreach(var transaction in jsonData) {
				Console.WriteLine(transaction.Amount);
			}
			

	
	}
}



//Pairing transactions with users for ListAll Method; 
//We have two lists - a <list>Transactions and a list<Accounts> 
//Loop through our list of accounts - i.e all the unique in the DB
//create a variable -e.g. 'total owe/owed'
// For each person, loop through the transactions list - 
// if they're in 'Person to' : - the amount : in personFrom + the amount; 
//this class that reads the data from the csv file returns the data to us when we call GetTransactionData();
//in Program.cs we need to create a new instance of the DataReader which returns a List<Transaction> transactions (array of transactions from the read file)
//we need to store the returned data in a List<Transaction> again - seems like a duplication?

// namespace SupportBank;

// public class DataReader 
// {
// 	public List<Transaction> GetTransactionData()
// 	{
// 		string path = @"./Transactions2014.csv";
// 		string[] lines = System.IO.File.ReadAllLines(path);

// 		List<Transaction> transactions = new List<Transaction>();


// 		foreach(string line in lines.Skip(1))
// 		{
// 			string[] rows = line.Split(",");
// 			string date = rows[0];
// 			string from = rows[1];
// 			string to = rows[2];
// 			string detail = rows[3];
// 			decimal amount = decimal.Parse(rows[4]);

// 			Transaction newTransaction = new Transaction(date, from, to, detail, amount);
// 			transactions.Add(newTransaction);

// 			//Console.WriteLine(uniqueTransaction.Date); ---- this works
// 			//Console.WriteLine(uniqueTransaction.To); ---- this works
	
// 		}
// 		// Console.WriteLine(allTransactions);
// 		return transactions;
// 	}
// }