namespace ATM.Core.Domain
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public int CardId { get; protected set; }

        public float Amount { get; protected set; }

        public float? BalanceBefore { get; protected set; }

        public float BalanceAfter { get; protected set; }

        public int TransactionType { get; protected set; }

        public DateTime TransactionDate { get; protected set; }

        [ForeignKey("CardId")]
        public virtual Card Card { get; protected set; }

        protected Transaction()
        {

        }

        public Transaction(int cardId, float amount, float? balanceBefore, float balanceAfter, int transactionType)
        {
            CardId = cardId;
            Amount = amount;
            BalanceBefore = balanceBefore;
            BalanceAfter = balanceAfter;
            TransactionType = transactionType;
            TransactionDate = DateTime.Now;
        }

        public Transaction(int id, int cardId, float amount, float? balanceBefore, float balanceAfter, int transactionType)
        {
            Id = id;
            CardId = cardId;
            Amount = amount;
            BalanceBefore = balanceBefore;
            BalanceAfter = balanceAfter;
            TransactionType = transactionType;
            TransactionDate = DateTime.Now;
        }
    }
}
