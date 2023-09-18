namespace ATM.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public string CardNumber { get; protected set; }

        public short Pin { get; protected set; }

        public int AccountId { get; protected set; }

        public bool IsLocked { get; protected set; }

        public int FailedAttempts { get; protected set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; protected set; }

        protected Card ()
        {
        }

        public Card(int id, string cardNumber, short pin, int accountId, bool isLocked, int failedAttempts)
        {
            Id = id;
            CardNumber = cardNumber;
            Pin = pin;
            AccountId = accountId;
            IsLocked = isLocked;
            FailedAttempts = failedAttempts;
        }

        public void UpdateFailedAttempts(int failedAttempts, bool? isLocked)
        {
            FailedAttempts = failedAttempts;
            if (isLocked.HasValue)
            {
                IsLocked = isLocked.Value;
            }
        }
    }
}
