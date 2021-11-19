using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SupportBank
{
    class Program
    {
        static Dictionary<string, Account> Balances = new Dictionary<string, Account>();
        static void Main(string[] args)
        {     
            string path = @"C:\Users\Jim.Davey\Work\CBootcamp\CBootcamp\SupportBank\Transactions2014.csv";
            string[] newText = File.ReadAllLines(path);
            string[] newerText = newText.Skip(1).ToArray();
           
            foreach (string line in newerText)
            {
                string[] trans = line.Split(',');
                DateTime date = DateTime.Parse(trans[0]);
                string to = trans[1];
                string from = trans[2];
                string narrative = trans[3];
                decimal amount = decimal.Parse(trans[4]);

                Transaction transaction = new Transaction(DateTime.Parse(trans[0]), trans[1], trans[2], trans[3], decimal.Parse(trans[4]));
                if (!Balances.ContainsKey(trans[1]))
                    {
                    Account account = new Account(trans[1], 0);
                    Balances.Add(account.Name, account);
                    }
                if (!Balances.ContainsKey(trans[2]))
                {
                    Account account = new Account(trans[2], 0);
                    Balances.Add(account.Name, account);
                }

                Balances[from].Balance -= amount;
                Balances[to].Balance += amount;
            }
            PrintAllAccounts();

            //got to look through each transaction in order to update the account.Balance of the To and From.
            //not sure how to loop through each transaction
            //syntax !!!
            //
              
            
                // loop through each transaction, check (if) name in to or from, print the data in a console.writeline
                /*
                string ListTransaction(string name)
                    {
                        foreach (var transaction in Transaction)
                        {
                            if (name == transaction[1])
                            {
                                Console.WriteLine($"On {0}, {1} paid {2} £{3} for {4}",
                                    transaction[0],
                                    transaction[1],
                                    transaction[2],
                                    transaction[4],
                                    transaction[3]);
                            }
                            else if (name == transaction[2])
                            {
                                Console.WriteLine($"On {0}, {1} paid {2} £{3} for {4}",
                                    transaction[0],
                                    transaction[1],
                                    transaction[2],
                                    transaction[4],
                                    transaction[3]);
                            }
                        }
                    }
                */


            // .split 
            // creating class of transactions and one for accounts 
            // class of person 
            // dictionary key: name , value: balance 
            // transaction list inside the accounts class 
            // then worry about transactions 
            /*
            foreach (KeyValuePair<string, Account> x in Balances)
            {
                Console.WriteLine(x.Key);
                Console.WriteLine(x.Value.Balance);
            }
            */
        }

        static void PrintAllAccounts()
        {
            foreach (var acc in Balances)
            {
                Console.WriteLine(acc.Key + "," + acc.Value.Balance);
            }
        }
    }
}
