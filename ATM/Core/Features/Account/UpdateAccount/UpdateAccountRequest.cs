namespace ATM.Core.Features.Account.UpdateAccount
{
    using MediatR;

    public class UpdateAccountRequest : IRequest<Unit>
    {
        public UpdateAccountDto UpdateAccountDto { get; set; }
    }
}