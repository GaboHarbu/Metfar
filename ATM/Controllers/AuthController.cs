namespace ATM.Controllers
{
    using Core.Abstarctions;
    using Core.Features.Auth.Login;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/controller")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IJwtTokenService jwtTokenService, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("login")]
        public IActionResult Login(string cardNumber, int pin)
        {
            var request = new LoginRequest
            {
                CardNumber = cardNumber, 
                Pin = pin
            };

            var response =  _mediator.Send(request);

            return Ok(response.Result);
        }
    }
}
