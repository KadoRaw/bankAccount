namespace bankAccount.Lib
{
    public class Transaction
    {
        public decimal Amount { get; set; } 
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Transaction(decimal Amount, DateTime Date, string note) // Ctor.
        {
            this.Amount = Amount;
            this.Date = Date;
            this.Notes = note;
        }
    }
   
}
