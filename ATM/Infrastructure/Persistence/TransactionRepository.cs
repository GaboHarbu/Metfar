using ATM.Core.Abstarctions;
using ATM.Infrastructure.Persistence.EntityMapping;
using ATM.Core.Domain;

namespace ATM.Infrastructure.Persistence
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ATMContext _context;

        public TransactionRepository(ATMContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetTransactions(int cardId)
        {
            return _context.Transactions.Where(t => t.CardId == cardId);
        }

        public void Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}