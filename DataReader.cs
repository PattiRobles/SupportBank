//this class that reads the data from the csv file returns the data to us when we call GetTransactionData();
//in Program.cs we need to create a new instance of the DataReader which returns a List<Transaction> transactions (array of transactions from the read file)
//we need to store the returned data in a List<Transaction> again - seems like a duplication?

namespace SupportBank;

public class DataReader 
{
	public List<Transaction> GetTransactionData()
	{
		string path = @"./Transactions2014.csv";
		string[] lines = System.IO.File.ReadAllLines(path);

		List<Transaction> transactions = new List<Transaction>();


		foreach(string line in lines.Skip(1))
		{
			string[] rows = line.Split(",");
			string date = rows[0];
			string from = rows[1];
			string to = rows[2];
			string detail = rows[3];
			decimal amount = decimal.Parse(rows[4]);

			Transaction newTransaction = new Transaction(date, from, to, detail, amount);
			transactions.Add(newTransaction);

			//Console.WriteLine(uniqueTransaction.Date); ---- this works
			//Console.WriteLine(uniqueTransaction.To); ---- this works
	
		}
		// Console.WriteLine(allTransactions);
		return transactions;
	}
}