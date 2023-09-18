namespace ATM.Core.Features.Card.UpdateCard
{
    public class UpdateCardDto
    {
        public int Id { get; set; }

        public int FailedAttempts { get; set; }

        public bool? IsLocked { get; set; }
    }
}
