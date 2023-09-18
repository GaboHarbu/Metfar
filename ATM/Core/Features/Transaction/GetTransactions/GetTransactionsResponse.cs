namespace ATM.Core.Features.Transaction.GetTransactions
{
    using Core.Model;

    public class GetTransactionsResponse
    {
        public IEnumerable<TransactionModel> Transactions { get; }

        public GetTransactionsResponse(IEnumerable<TransactionModel> transactions)
        {
            Transactions = transactions;
        }

        public PaginatedTransactionsResponse Paginate(int page, int pageSize)
        {
            var totalItems = Transactions.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginatedTransactions = Transactions
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedTransactionsResponse
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Transactions = paginatedTransactions
            };
        }
    }
}