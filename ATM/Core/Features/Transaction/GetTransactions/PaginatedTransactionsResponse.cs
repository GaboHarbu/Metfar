namespace ATM.Core.Features.Transaction.GetTransactions
{
    using System.Collections.Generic;
    using Core.Model;

    public class PaginatedTransactionsResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<TransactionModel> Transactions { get; set; }
    }
}
