namespace ATM.Core.Features.Transaction.GetTransactions
{
    using ATM.Core.Validations;
    using Core.Abstarctions;
    using Core.Mapping;
    using MediatR;

    public class GetTransactionsHandler : IRequestHandler<GetTransactionsRequest, GetTransactionsResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IMediator _mediator;

        public GetTransactionsHandler(ICardRepository cardRepository, ITransactionRepository transactionRepository, IMediator mediator)
        {
            _transactionRepository = transactionRepository;
            _cardRepository = cardRepository;
            _mediator = mediator;
        }

        public async Task<GetTransactionsResponse> Handle(GetTransactionsRequest request, CancellationToken cancellationToken)
        {
            RequestValidator.Validate(request);

            var card = _cardRepository.GetByCardNumber(request.CardNumber);
            
            CardValidator.Validate(card);

            var transactions = _transactionRepository.GetTransactions(card.Id);

            return new GetTransactionsResponse(transactions.ToModel());
        }
    }
}