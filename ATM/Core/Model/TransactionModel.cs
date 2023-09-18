namespace ATM.Core.Model
{
    public class TransactionModel
    {
        public int Id { get; set; }

        public float? Amount { get; set; }

        public float? BalanceBefore { get; set; }

        public float? BalanceAfter { get; set; }

        public int TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
