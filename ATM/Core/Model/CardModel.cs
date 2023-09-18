namespace ATM.Core.Model
{
    public class CardModel
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public short Pin { get; set; }

        public AccountModel Account { get; set; }
    }
}
