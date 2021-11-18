using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {     
            string path = @"C:\Users\Jim.Davey\Work\CBootcamp\CBootcamp\SupportBank\Transactions2014.csv";

            string[] newText = File.ReadAllLines(path);
            string[] newerText = newText.Skip(1).ToArray();
            Dictionary<string, Account> Balances = new Dictionary<string, Account>();
            // remove first line of newText?
            foreach (string line in newerText)
            {
                string[] trans = line.Split(',');                
                Transaction transaction = new Transaction();
                transaction.Date = DateTime.Parse(trans[0]);
                transaction.From = trans[1];
                transaction.To = trans[2];
                transaction.Narrative = trans[3];
                transaction.Amount = decimal.Parse(trans[4]);

                if (!Balances.ContainsKey(trans[1]))
                    {
                    Account account = new Account();
                    account.Name = trans[1];
                    account.Balance = 0;
                    Balances.Add(account.Name, account);
                    }
                else if (!Balances.ContainsKey(trans[2]) && !Balances.ContainsKey(trans[1]))
                {
                    Account account = new Account();
                    account.Name = trans[1];
                    account.Balance = 0;
                    Balances.Add(account.Name, account);
                }
            }

            int UpdateBalance()
            {
                //got to look through each transaction. Update the account.Balance of the To and From.

                foreach (var transaction in Transaction)
                {

                }
            }



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
    }
}
