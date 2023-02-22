//we have created an instance of the data reader.
//and have called its method GetTransactionData();
//this method has provided us with a List<Transaction>
//Afterwards I'm calling the GenerateTransactionNarrative(), 
//which is available even if i havent created an instance of the class Transaction 
//is this because the return of my instance of DataReader is actually a List of the type Transaction?
//therefore existence of instance Transaction is implied / or created when we create the DtaReader instance

using SupportBank;

DataReader dataReader = new DataReader();
List<Transaction> transactions = dataReader.GetTransactionData(); //returns the data

foreach(Transaction transaction in transactions) 
{
	transaction.GenerateTransactionNarrative(); //prints verbose data for each transaction 
}

Account account = new Account();
account.PopulateAccount(transaction.From);
account.CalculateAccountBalance();

// Transaction transaction = new Transaction(transaction.Date, transaction.From, transaction.To, transaction.Detail, transaction.Amount);
// transaction.GenerateTransactionData();


