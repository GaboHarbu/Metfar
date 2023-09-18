namespace ATM.Core.Model
{
    public class AccountModel
    {
        public int Id { get; set; }

        public int AccountNumber { get; set; }

        public string Username { get; set; }

        public float Balance { get; set; }

        public DateTime? LastWithdrawalDate { get; set; }
    }
}
