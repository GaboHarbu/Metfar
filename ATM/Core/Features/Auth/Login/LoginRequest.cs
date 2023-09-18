namespace ATM.Core.Features.Auth.Login
{
    using MediatR;

    public class LoginRequest : IRequest<LoginResponse>
    {
        public string CardNumber { get; set; }

        public int Pin { get; set; }
    }
}
