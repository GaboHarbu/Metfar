namespace ATM.Core.Abstarctions
{
    public interface IJwtTokenService
    {
        string GenerateToken(string cardNumber);
    }
}
