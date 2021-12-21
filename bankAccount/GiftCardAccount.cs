namespace bankAccount.Lib
{
 
        public class GiftCardAccount: BankAccount
        {
        private decimal monthlyDeposit = 0;
            public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit=0) : base(name,initialBalance)
            {
                this.monthlyDeposit = monthlyDeposit;
            }
        public override void PerformMonthEndTransaction()
        {
            if(this.monthlyDeposit != 0)
            {
                MakeDeposit(this.monthlyDeposit, DateTime.Now, "Add monthly deposit");

            }
        }
    }

   
}
