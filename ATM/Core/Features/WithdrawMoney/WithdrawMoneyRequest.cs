namespace ATM.Core.Features.WithdrawMoney
{
    using MediatR;

    public class WithdrawMoneyRequest : IRequest<WithdrawMoneyResponse>
    {
        public string CardNumber { get; set; }
        public float Amount { get; set; }
    }
}
