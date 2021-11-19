using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SupportBank
{
    class Program
    {
        static Dictionary<string, Account> Balances = new Dictionary<string, Account>();
        static string[] newerText;
        static void Main(string[] args)
        {
            string path = @"C:\Users\Jim.Davey\Work\CBootcamp\CBootcamp\SupportBank\Transactions2014.csv";
            string[] newText = File.ReadAllLines(path);
            newerText = newText.Skip(1).ToArray();
           
            foreach (string line in newerText)
            {
                string[] trans = line.Split(',');
                DateTime date = DateTime.Parse(trans[0]);
                string to = trans[1];
                string from = trans[2];
                string narrative = trans[3];
                decimal amount = decimal.Parse(trans[4]);

                Transaction transaction = new Transaction(date, to, from, narrative, amount);
                if (!Balances.ContainsKey(to))
                    {
                    Account account = new Account(to, 0);
                    Balances.Add(account.Name, account);
                    }
                if (!Balances.ContainsKey(from))
                {
                    Account account = new Account(from, 0);
                    Balances.Add(account.Name, account);
                }

                Balances[from].Balance -= amount;
                Balances[to].Balance += amount;

                
            }

            /*
            foreach (KeyValuePair<string, Account> x in Balances)
            {
                Console.WriteLine(x.Key);
                Console.WriteLine(x.Value.Balance);
            }
            */
            Console.WriteLine("What would you like to do?\n1) Print All Accounts \n2) List Someones Transactions");
            int answer = int.Parse(Console.ReadLine());
            if (answer == 1)
            {
                PrintAllAccounts();
                Console.ReadLine();
            } else if (answer == 2)
            {
                Console.WriteLine("Please chose someone from the following list:");
                foreach (var acc in Balances)
                {
                    Console.WriteLine(acc.Key);
                }
                ListTransaction(Console.ReadLine());
            } else
            {
                Console.WriteLine("That wasn't a 1 or 2 now was it. I am leaving you now.");
            }
                
        }
       
        static void PrintAllAccounts()
        {
            foreach (var acc in Balances)
            {
                Console.WriteLine(acc.Key + "," + acc.Value.Balance);
            }
        }
        static void ListTransaction(string name)
        {
            foreach (string line in newerText)
            {
                string[] trans = line.Split(',');
                DateTime date = DateTime.Parse(trans[0]);
                string to = trans[1];
                string from = trans[2];
                string narrative = trans[3];
                decimal amount = decimal.Parse(trans[4]);
                if (name == to)
                {
                    Console.WriteLine($"On {date.ToShortDateString()}, {to} paid {from} £{amount} for {narrative}.");
                }
                if (name == from)
                {
                    Console.WriteLine($"On {date.ToShortDateString()}, {to} paid {from} £{amount} for {narrative}.");
                }
                
            }
        }

       
        

    }
}
