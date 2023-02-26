namespace SupportBank;

public class TransactionJSON
{
	public DateTime Date {get; set;}

	public string FromAccount {get; set;}
	public string ToAccount {get; set;}
	public string Details {get; set;}
	public string Amount {get; set;}

	//constructor
	public TransactionJSON (DateTime date, string from, string to, string details, string amount)
	{
		Date = date;
		FromAccount = from;
		ToAccount = to;
		Details = details;
		Amount = amount;
	}
}