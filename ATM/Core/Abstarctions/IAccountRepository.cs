namespace ATM.Core.Abstarctions
{
    using ATM.Core.Domain;

    public interface IAccountRepository
    {
        Account GetAccount(int Id);

        Task Update(int accountId, float newBalance, DateTime? lastWithdrawalDate);
    }
}
