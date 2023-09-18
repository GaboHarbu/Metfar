namespace ATM.Core.Features.WithdrawMoney
{
    using Core.Model;

    public class WithdrawMoneyResponse
    {
        public TransactionModel Transaction { get; }

        public WithdrawMoneyResponse(TransactionModel transaction)
        {
            Transaction = transaction;
        }
    }
}
