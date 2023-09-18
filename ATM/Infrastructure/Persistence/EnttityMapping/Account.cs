namespace Db.Persistence.EnttityMapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public int AccountNumber { get; protected set; }

        public string Username { get; protected set; }

        public decimal Balance { get; protected set; }

        public DateTime? LastWithdrawalDate { get; protected set; }

        public bool Blocked { get; protected set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}


