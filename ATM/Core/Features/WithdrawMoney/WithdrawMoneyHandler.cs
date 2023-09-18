namespace ATM.Core.Features.WithdrawMoney
{
    using Core.Abstarctions;
    using Core.Features.Account.UpdateAccount;
    using Core.Features.Transaction.AddTransaction;
    using Core.Model;
    using Core.Validations;
    using MediatR;


    public class WithdrawMoneyHandler : IRequestHandler<WithdrawMoneyRequest, WithdrawMoneyResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;

        public WithdrawMoneyHandler(ICardRepository cardRepository, IAccountRepository accountRepository,
                                    ITransactionRepository transactionRepository , IMediator mediator)
        { 
            _cardRepository = cardRepository; 
            _accountRepository = accountRepository; 
            _mediator = mediator;   
        }

        public async Task<WithdrawMoneyResponse> Handle(WithdrawMoneyRequest request, CancellationToken cancellationToken)
        { 
            RequestValidator.Validate(request);
            var card = _cardRepository.GetByCardNumber(request.CardNumber);

            CardValidator.Validate(card);

            var account = _accountRepository.GetAccount(card.AccountId);

            AccountValidator.Validate(account);

            ValidateWithdraw(request, account);

            var transaction = await GenerateTransaction(request, account, card);

            return new WithdrawMoneyResponse(transaction);
        }

        private async Task<TransactionModel> GenerateTransaction(WithdrawMoneyRequest request, Domain.Account account, Domain.Card card)
        {
            var balanceBefore = account.Balance;
            var balanceAfter = balanceBefore - request.Amount;

            var transactionRequest = new AddTransactionRequest
            {
                Amount = request.Amount,
                BalanceBefore = balanceBefore,
                BalanceAfter = balanceAfter,
                Card = card,
                CardId = card.Id,
                TransactionType = 1
            };

            var transactionResponse = await _mediator.Send(transactionRequest);
            var transaction = transactionResponse.Transaction;

            var updateAccountRequest = new UpdateAccountRequest
            {
                UpdateAccountDto = new UpdateAccountDto
                {
                    Id = account.Id,
                    Balance = balanceAfter,
                    LastWithdrawalDate = transaction.TransactionDate
                }
            };

            await _mediator.Send(updateAccountRequest);
            return transaction;
        }

        private static void ValidateWithdraw(WithdrawMoneyRequest request, Domain.Account account)
        {
            if (request.Amount <= 0)
            {
                throw new InvalidOperationException("Withdrawal amount must be greater than zero.");
            }

            if (account.Balance < request.Amount)
            {
                throw new InvalidOperationException("Withdrawal cannot be performed as the balance is insufficient.");
            }
        }
    }
}
