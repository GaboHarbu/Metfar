namespace ATM.Core.Features.Account.UpdateAccount
{
    using Core.Abstarctions;
    using MediatR;
    using Core.Validations;

    public class UpdateAccountHandler : IRequestHandler<UpdateAccountRequest, Unit>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Unit> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            RequestValidator.Validate(request);

            await _accountRepository.Update(request.UpdateAccountDto.Id, request.UpdateAccountDto.Balance,
                request.UpdateAccountDto.LastWithdrawalDate);

            return Unit.Value;
        }
    }
}