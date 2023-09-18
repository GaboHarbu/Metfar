namespace ATM.Core.Mapping
{
    using Core.Domain;
    using Core.Features.Transaction.AddTransaction;
    using Core.Model;

    public static class TransactionMapping
    {
        public static TransactionModel ToModel(this Transaction transaction)
        {
            return new TransactionModel
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                BalanceBefore = transaction.BalanceBefore,
                BalanceAfter = transaction.BalanceAfter,
                TransactionDate = transaction.TransactionDate,
                TransactionType = transaction.TransactionType
            };
        }
        public static Transaction ToDomain(this AddTransactionRequest request)
        {
            var card = new Transaction(request.CardId, request.Amount, request.BalanceBefore, request.BalanceAfter, request.TransactionType);
            return card;
        }

        public static IEnumerable<TransactionModel> ToModel(this IEnumerable<Transaction> transactions)
        {
            return transactions.Select(x=> x.ToModel());
        }
    }
}
