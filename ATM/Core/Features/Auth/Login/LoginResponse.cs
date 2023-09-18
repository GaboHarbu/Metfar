namespace ATM.Core.Features.Auth.Login
{
    public class LoginResponse
    {
        public string Token { get; }

        public LoginResponse(string token)
        {
            Token = token;
        }
    }
}
