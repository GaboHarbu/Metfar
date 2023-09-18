namespace ATM.Core.Features.Transaction.GetTransactions
{
    using MediatR;

    public class GetTransactionsRequest : IRequest<GetTransactionsResponse>
    {
        public string CardNumber { get; set; }
       
    }
}
