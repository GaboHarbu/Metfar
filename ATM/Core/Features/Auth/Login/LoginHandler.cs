namespace ATM.Core.Features.Auth.Login
{
    using Core.Abstarctions;
    using Core.Features.Card.UpdateCard;
    using Core.Validations;
    using MediatR;

    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMediator _mediator;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginHandler(ICardRepository cardRepository, IMediator mediator, IJwtTokenService jwtTokenService)
        {
            _cardRepository = cardRepository;
            _mediator = mediator;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            RequestValidator.Validate(request);

            var card = _cardRepository.GetByCardNumber(request.CardNumber);

            CardValidator.Validate(card);

            await PinValidator(request, card);

            var token = _jwtTokenService.GenerateToken(request.CardNumber);

            return new LoginResponse(token);

        }

        private async Task PinValidator(LoginRequest request, Domain.Card card)
        {
            if (card.Pin != request.Pin)
            {
                var failedAttempts = card.FailedAttempts + 1;

                var updateCardDto = new UpdateCardDto
                {
                    Id = card.Id,
                    FailedAttempts = failedAttempts
                };

                if (failedAttempts >= 4)
                {
                    updateCardDto.IsLocked = true;
                }

                var updateCardRequest = new UpdateCardRequest
                {
                    UpdateCardDto = updateCardDto
                };

                var cardUpdate = await _mediator.Send(updateCardRequest);

                throw new InvalidOperationException($"Invalid pin for card {request.CardNumber}.");
            }
        }
    }
}
