namespace ATM.Core.Mapping
{
    using Core.Domain;
    using Core.Model;
        
    public static class CardMapping
    {
        public static CardModel ToModel(this Card card)
        {
            return new CardModel
            {
                Id = card.Id,
                CardNumber = card.CardNumber,
                Pin = card.Pin,
                Account = card.Account.ToModel()
            };
        }
    }
}
