namespace SupportBank;

public class PersonalAccount 
{
	//data members
	public List<AccountUser> AccountUserList {get; set;}
	public List<Transaction> TransactionList {get; set;}

	//constructors
	public PersonalAccount(List<AccountUser> ourAccountUserList, List<Transaction> ourTransactionList)
	{
		AccountUserList = ourAccountUserList;
		TransactionList = ourTransactionList;
	}

	//methods
	public void CalculateBalanceAllAccountUsers() // further tailoring to provide balance of each user
	{
		foreach(AccountUser user in AccountUserList)
		{
			decimal balance = 0;

			foreach( Transaction transaction in TransactionList) 
			{
				if(transaction.From.Name == user.Name)
				{
					balance += transaction.Amount; // if name is in FROM field, the money comes from him
				}

				if(transaction.To.Name == user.Name)
				{
					balance -= transaction.Amount;
				}
			}
			Console.WriteLine($"{user.Name} net balance: {balance}");
		}
	}

	public void GetPersonalAccountUserTransactions()
	{
		int TransactionCounter = 0;
		Console.WriteLine("Select a user to view all their transactions");
		string response = Console.ReadLine();
		if (AccountUserList.Any(element => element.Name == response)) 
		{
			foreach (Transaction transaction in TransactionList)
			{
				if (transaction.From.Name == response || transaction.To.Name == response) 
				{
					TransactionCounter++;
					Console.WriteLine($"\nTransaction {TransactionCounter}: \nDate:{transaction.Date} \nFrom: {transaction.From.Name} \nTo: {transaction.To.Name} \nDetails: {transaction.Details} \nAmount: {transaction.Amount}\n");
				}
			}
		}
		else
		{
			Console.WriteLine("Error - User not found");
		}
	}
}