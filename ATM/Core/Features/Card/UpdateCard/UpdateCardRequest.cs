using MediatR;

namespace ATM.Core.Features.Card.UpdateCard
{
    public class UpdateCardRequest : IRequest<Unit>
    {
        public UpdateCardDto UpdateCardDto { get; set; }
    }
}
