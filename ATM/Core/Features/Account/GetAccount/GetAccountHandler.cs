namespace ATM.Core.Features.Account.GetAccount
{
    using Core.Validations;
    using Core.Abstarctions;
    using Core.Mapping;
    using MediatR;

    public class GetAccountHandler : IRequestHandler<GetAccountRequest, GetAccountResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;

        public GetAccountHandler(ICardRepository cardRepository, IAccountRepository accountRepository, IMediator mediator)
        {
            _cardRepository = cardRepository;
            _accountRepository = accountRepository;
            _mediator = mediator;
        }

        public async Task<GetAccountResponse> Handle(GetAccountRequest request, CancellationToken cancellationToken)
        {
            Validations.RequestValidator.Validate(request);

            var card = _cardRepository.GetByCardNumber(request.CardNumber);

            CardValidator.Validate(card);

            var account = _accountRepository.GetAccount(card.AccountId);
            
            AccountValidator.Validate(account);

            return new GetAccountResponse(account.ToModel());
        }
    }
}
