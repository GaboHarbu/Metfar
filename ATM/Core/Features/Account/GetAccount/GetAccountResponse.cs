namespace ATM.Core.Features.Account.GetAccount
{
    using Core.Model;

    public class GetAccountResponse
    {
        public AccountModel Account { get; }

        public GetAccountResponse(AccountModel account)
        {
            Account = account;
        }
    }
}
