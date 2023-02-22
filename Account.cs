//PopulateAccount() is void because it performs an action -populate the lists- but it does not return anything
namespace SupportBank;
public class Account 
{
	public string Name {get; set;}
	public List<Transaction> OutgoingPayment {get; set;}
	public List<Transaction> IncomingPayment {get; set;}

	//method
	public void PopulateAccount(string name, List<Transaction> transactions) // why dont we follow exact field/property set up?
	{
		List<Transaction> OutgoingPayment = new List<Transaction>();
		List<Transaction> IncomingPayment = new List<Transaction>();

		//foreach( List<Transaction> transaction in transactions) { - unable to use foreach, cant convert from List-Transactions to transaction
		for (int i = 0; i < transactions.Count; i++) {

			Transaction transaction = transactions[i]; // set a variable for each item in the transaction list we have passed as a parameter

			if (transactions[i].From == name) 
			{
				OutgoingPayment.Add(transactions[i]);
				Console.WriteLine(OutgoingPayment);
			}

			if (transactions[i].To == name)
			{
				IncomingPayment.Add(transactions[i]);
				Console.WriteLine(IncomingPayment);
			}

		}
		
	}

	public decimal CalculateAccountBalance() //returns balance, numerical
	{
		decimal balance = 0;

		for(int i = 0; i < OutgoingPayment.Count; i++)
		{
			balance -= OutgoingPayment[i].Amount;
		}

		for(int i = 0; i < IncomingPayment.Count; i++)
		{
			balance += IncomingPayment[i].Amount;
		}

		return balance;
	}
}
