namespace ATM.Infrastructure.Persistence
{
    using global::ATM.Core.Abstarctions;
    using global::ATM.Core.Domain;
    using global::ATM.Infrastructure.Persistence.EntityMapping;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    public class CardRepository : ICardRepository
    {
        private readonly ATMContext _context;

        public CardRepository(ATMContext context)
        {
            _context = context;
        }

        public Card GetByCardNumber(string cardNumber)
        {
            return _context.Cards
                .Where(c => c.CardNumber == cardNumber)
                .Include(c => c.Account)
                .FirstOrDefault();
        }

        public bool ValidateCard(string cardNumber, short pin)
        {
            var card = _context.Cards
                .FirstOrDefault(c => c.CardNumber == cardNumber && c.Pin == pin);

            return card != null;
        }

        public async Task Update(int cardId, int failedAttempts, bool? isLocked)
        {
            var card = await _context.Cards.FindAsync(cardId);


            card.UpdateFailedAttempts(failedAttempts, isLocked);

            await _context.SaveChangesAsync();
        }
    }
}
