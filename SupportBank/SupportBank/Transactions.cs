using System;

public class Transaction

{
		public DateTime Date { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public string Narrative { get; set; }
		public decimal Amount { get; set; }
	
	public Transaction(DateTime date, string from, string to, string narrative, decimal amount)
    {
		Date = date;
		From = from;
		To = to;
		Narrative = narrative;
		Amount = amount;
    }

	/*public string GetTransactions()
    {
		foreach(string line in Transaction)
        {

        }
    }*/
}
