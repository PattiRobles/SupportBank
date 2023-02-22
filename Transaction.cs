namespace SupportBank;

public class Transaction 
{
	public string Date {get; set;}
	public string From {get; set;}
	public string To {get; set;}
	public string Detail {get; set;}
	public decimal Amount {get; set;}

	//constructor
	public Transaction (string date, string from, string to, string detail, decimal amount) 
	{
		Date = date;
		From = from;
		To = to;
		Detail = detail;
		Amount = amount;
	}

	public void GenerateTransactionNarrative()
	{
		Console.WriteLine($"On {Date}, {From} lent £{Amount} to {To}");
	}

}	