using System;
using System.Collections.Generic;

public class Account
{ 
		public string Name { get; set; }
		public decimal Balance { get; set; }
		//public List<Transactions> TransactionList { get; set; }
		
	public Account(string name, decimal balance)
    {
		Name = name;
		Balance = balance;
    }
	
}

