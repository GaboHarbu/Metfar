namespace ATM.Core.Features.Transaction.AddTransaction
{
    using MediatR;

    public class AddTransactionRequest : IRequest<AddTransactionResponse>
    {
        public int CardId { get; set; }

        public float Amount { get; set; }

        public float? BalanceBefore { get; set; }

        public float BalanceAfter { get; set; }

        public int TransactionType { get; set; }

        public Domain.Card Card { get; set; }
    }
}
