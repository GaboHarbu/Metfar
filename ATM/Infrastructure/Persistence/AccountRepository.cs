namespace ATM.Infrastructure.Persistence
{
    using global::ATM.Core.Abstarctions;
    using global::ATM.Core.Domain;
    using global::ATM.Infrastructure.Persistence.EntityMapping;
    using System.Linq;


    public class AccountRepository : IAccountRepository
    {
        private readonly ATMContext _context;

        public AccountRepository(ATMContext context)
        {
            _context = context;
        }

        public Account GetAccount(int Id)
        {
            return _context.Accounts
                .FirstOrDefault(a => a.Id == Id);
        }

        public async Task Update(int accountId, float newBalance, DateTime? lastWithdrawalDate)
        {
            var account = await _context.Accounts.FindAsync(accountId);

            if (account == null)
            {
                throw new NullReferenceException("Account not found.");
            }

            account.UpdateBalanceAndLastWithdrawalDate(newBalance, lastWithdrawalDate);

            await _context.SaveChangesAsync();
        }
    }
}