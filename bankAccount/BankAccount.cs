namespace bankAccount.Lib
{
    public partial class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public BankAccount(string name, decimal initialBalance) // her kullanıcı için sadece bir kez çalışacağı için accountNumberSeed'e bir ekledik. Ctor olarak geçiyor.
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();

            MakeDeposit(initialBalance, DateTime.Now, "Başlangıç Bakiyesi");

            accountNumberSeed++; 
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                Console.Error.WriteLine("Negatif bakiye ekleyemezsiniz.");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime Date, string note)
        {
            if (Balance-amount <0)
            {
                Console.Error.WriteLine("Yeterli bakiye bulunmamaktadır.");
            }

            var withdrawal = new Transaction(-amount, Date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\t\tBalance\t\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            return report.ToString();
        }

        public virtual void PerformMonthEndTransaction()
        {

        }

    }
}
