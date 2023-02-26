namespace SupportBank;
public class Transaction
{
	//data memebers
	public DateTime Date { get; set; }
	public AccountUser From { get; set; }
	public AccountUser To { get; set; }
	public string Details { get; set; }
	public decimal Amount { get; set; }

//constructor
	public Transaction (DateTime date, AccountUser from, AccountUser to, string details, decimal amount ) 
	//lowercase indicates parameter, value to vary with individual instances
	//capitals indicate data fields/properties
	{
		Date = date;
		From = from;
		To = to;
		Details = details;
		Amount = amount;
	}

//method
}

