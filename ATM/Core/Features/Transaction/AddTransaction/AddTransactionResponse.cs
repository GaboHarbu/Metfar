namespace ATM.Core.Features.Transaction.AddTransaction
{
    using Core.Model;
    using MediatR;

    public class AddTransactionResponse : IRequest<AddTransactionRequest>
    {
        public TransactionModel Transaction { get; }

        public AddTransactionResponse(TransactionModel transaction)
        {
            Transaction = transaction;
        }
    }
}
