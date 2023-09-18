namespace Db.Persistence.EnttityMapping
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public int AccountId { get; protected set; }

        public decimal Amount { get; protected set; }

        public string TransactionType { get; protected set; }

        public DateTime TransactionDate { get; protected set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; protected set; }
    }
}
