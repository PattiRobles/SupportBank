using Bank;

//Class Budget: 
//List<Transactions> 
//List<User>
//Method: ListAll
//Method: ListAccount(takes an User instance)* {loops through transactions and Console.WriteLines any transaction with their name in either to/from }
//CONSTRUCTOR (*string for the excel filepath*) {
//Run all the stuff you've got in CSVReader
// }

//Program.CS:
//Budget Budget2014 = new Budget(*filepath*)


//Class User

//Class Transaction

CSVReader csvReader = new CSVReader();

Budget Budget2014 = csvReader.GetTransactionDetails();

Console.WriteLine("See all users (1) \n all transactions for individual user (2)");
string userOption = Console.ReadLine();

if (userOption == "1")
{
	Budget2014.CalculateBalanceAllUsers();
}
else if (userOption == "2")
{
    Budget2014.GetPersonalTransactions();
}

else { Console.WriteLine("ERROR!"); }

// foreach (Transaction transaction in transactions) {

// Console.WriteLine(transaction.Amount);
//}

//Budget budgetFor2014: new Budget("*stringforCSVfilepath*"); 
//bugetFor2014.ListAll(); 

/*List<string> users = new transactions.to.Distinct();

foreach(Transaction user in users) {
    Console.WriteLine(user);
}
*/



//-------------------------------
//we have created an instance of the data reader.
//and have called its method GetTransactionData();
//this method has provided us with a List<Transaction>
//Afterwards I'm calling the GenerateTransactionNarrative(), 
//which is available even if i havent created an instance of the class Transaction 
//is this because the return of my instance of DataReader is actually a List of the type Transaction?
//therefore existence of instance Transaction is implied / or created when we create the DtaReader instance

// using SupportBank;

// DataReader dataReader = new DataReader();
// List<Transaction> transactions = dataReader.GetTransactionData(); //returns the data

// foreach(Transaction transaction in transactions) 
// {
// 	transaction.GenerateTransactionNarrative(); //prints verbose data for each transaction 
// }

// Account account = new Account(); 
// // create instance of Account to be able to use both its methods
// //populateAccount() and CalculateAccountBalance
// foreach( var transaction in transactions) {
// 	account.PopulateAccount(transaction.From, transactions); //HOW TO ACCESS NAME (i.e. From field)
// 	Console.WriteLine ($" {transaction.From} - net balance {account.CalculateAccountBalance}"); 
	
// 	// if method not invoked, i am printing name correctly but multiple entries per name as it is doing a 
// 	//foreach loop of the whole transaction file, rather than a filtered file with unique entries
// }





