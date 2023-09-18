using ATM.Core.Abstarctions;
using ATM.Core.Features.Account.UpdateAccount;
using ATM.Core.Validations;
using MediatR;

namespace ATM.Core.Features.Card.UpdateCard
{
    public class UpdateCardHandler : IRequestHandler<UpdateCardRequest, Unit>
    {
        private readonly ICardRepository _cardRepository;

        public UpdateCardHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Unit> Handle(UpdateCardRequest request, CancellationToken cancellationToken)
        {
            RequestValidator.Validate(request);

            await _cardRepository.Update(request.UpdateCardDto.Id, request.UpdateCardDto.FailedAttempts, request.UpdateCardDto.IsLocked);

            return Unit.Value;
        }
    }
}