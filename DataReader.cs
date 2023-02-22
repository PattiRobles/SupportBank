namespace SupportBank;

public class DataReader 
{
	public List<Transaction> GetTransactionDetails()
	{
		//string path = @"./Transactions2014.csv";

		string[] lines = System.IO.File.ReadAllLines("Transactions2014.csv");

		List<Transaction> allTransactions = new List<Transaction>();


		foreach(string line in lines.Skip(1))
		{
			string[] rows = line.Split(",");
			string date = rows[0];
			string to = rows[1];
			string from = rows[2];
			string detail = rows[3];
			decimal amount = decimal.Parse(rows[4]);


			Transaction uniqueTransaction = new Transaction(date, to, from, detail, amount);
			allTransactions.Add(uniqueTransaction);
			//Console.WriteLine(uniqueTransaction.Date);
			Console.WriteLine(uniqueTransaction.To);
			
		}
		// Console.WriteLine(allTransactions);
		return allTransactions;
	}
}