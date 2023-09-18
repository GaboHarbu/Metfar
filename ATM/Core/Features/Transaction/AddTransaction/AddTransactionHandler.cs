namespace ATM.Core.Features.Transaction.AddTransaction
{
    using ATM.Core.Validations;
    using Core.Abstarctions;
    using Core.Mapping;
    using MediatR;

    public class AddTransactionHandler : IRequestHandler<AddTransactionRequest, AddTransactionResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMediator _mediator;

        public AddTransactionHandler(ITransactionRepository transactionRepository, IMediator mediator)
        {
            _transactionRepository = transactionRepository;
            _mediator = mediator;
        }

        public async Task<AddTransactionResponse> Handle(AddTransactionRequest request, CancellationToken cancellationToken)
        {
            RequestValidator.Validate(request);

            var transaction = request.ToDomain();

            _transactionRepository.Add(transaction);
            await _transactionRepository.SaveChangesAsync();

            return new AddTransactionResponse(transaction.ToModel());
        }
    }
}
