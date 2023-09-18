namespace ATM.Core.Features.Account.GetAccount
{
    using MediatR;

    public class GetAccountRequest : IRequest<GetAccountResponse>
    {
        public string CardNumber { get; set; }
    }
}
