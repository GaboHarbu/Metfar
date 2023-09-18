namespace ATM.Core.Features.Account.UpdateAccount
{
    public class UpdateAccountDto
    {
        public int Id { get; set; }

        public float Balance { get; set; }

        public DateTime? LastWithdrawalDate { get; set; }
    }
}
