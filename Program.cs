using SupportBank;
using NLog;
using NLog.Config;
using NLog.Targets;

var config = new LoggingConfiguration();
var target = new FileTarget { FileName = @"C:\Training\SupportBank\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
LogManager.Configuration = config;

//creates a log file at location giveb in line 7, copy file path of othe file at same level and change param

//Class Budget: 
//List<Transactions> 
//List<User>
//Method: ListAll
//Method: ListAccount(takes an User instance)* {loops through transactions and Console.WriteLines any transaction with their name in either to/from }
//CONSTRUCTOR (*string for the excel filepath*) {
//Run all the stuff you've got in DataReader
// }

//Program.CS:
//Budget Budget2014 = new Budget(*filepath*)


//Class User

//Class Transaction
Console.WriteLine("Please enter the year that you would like to review: \nFor 2014 data, enter 1 \nFor 2015 data, enter 2 \nFor 2013 data, enter 3");
string response = Console.ReadLine();

if(response == "1") 
{
    response = "Transactions2014.csv";
}
if(response == "2")
{
        response = "TRansactions2015.csv";
}
DataReader dataReader = new DataReader();

PersonalAccount transactions2014 = dataReader.ReadTransactionData(response);

Console.WriteLine("Please select from the following options: \nFor all users's balances, enter 1\nFor individual user transactions, enter 2");
string userOption = Console.ReadLine();

if (userOption == "1")
{
	transactions2014.CalculateBalanceAllAccountUsers();
}
else if (userOption == "2")
{
    transactions2014.GetPersonalAccountUserTransactions();
}
else { Console.WriteLine("Error - incorrect selection, please enter 1 or 2"); }




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





