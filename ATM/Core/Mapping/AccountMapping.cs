namespace ATM.Core.Mapping
{
    using Core.Domain;
    using Core.Model;

    public static class AccountMapping
    {
        public static AccountModel ToModel(this Account account)
        {
            return new AccountModel
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Username = account.Username,
                Balance = account.Balance,
                LastWithdrawalDate = account.LastWithdrawalDate
            };
        }
    }
}
