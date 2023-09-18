namespace ATM.Core.Domain
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public int AccountNumber { get; protected set; }

        public string Username { get; protected set; }

        public float Balance { get; protected set; }

        public DateTime? LastWithdrawalDate { get; protected set; }

        protected Account()
        {
        }

        public Account(int id ,int accountNumber, string username, float balance, DateTime? lastWithdrawalDate)
        {
            Id = id;
            AccountNumber = accountNumber;
            Username = username;
            Balance = balance;
            LastWithdrawalDate = lastWithdrawalDate;
        }

        public void UpdateBalanceAndLastWithdrawalDate(float newBalance, DateTime? newLastWithdrawalDate)
        {
            Balance = newBalance;
            LastWithdrawalDate = newLastWithdrawalDate;
        }
    }
}
