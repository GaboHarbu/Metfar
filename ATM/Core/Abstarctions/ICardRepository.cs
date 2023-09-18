namespace ATM.Core.Abstarctions
{
    using ATM.Core.Domain;
    public interface ICardRepository
    {
        Card GetByCardNumber(string cardNummber);

        bool ValidateCard(string cardNumber, short pin);

        Task Update(int cardId, int failedAttempts, bool? isLocked);
    }
}
