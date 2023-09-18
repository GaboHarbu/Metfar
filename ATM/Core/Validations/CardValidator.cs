namespace ATM.Core.Validations
{
    public static class CardValidator
    {
        public static void Validate(Domain.Card card)
        {
            if (card == null)
            {
                throw new NullReferenceException("Card not found.");
            }

            if (card.IsLocked)
            {
                throw new InvalidOperationException("Operation cannot be performed as the card has been blocked.");
            }
        }
    }
}
