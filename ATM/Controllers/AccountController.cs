namespace ATM.Controllers
{
    using Core.Features.Account.GetAccount;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cardNumber")]
        public async Task<IActionResult> GetBalance(string cardNumber)
        {
            var request = new GetAccountRequest { CardNumber = cardNumber };
            var response = await _mediator.Send(request);

            return Ok(response.Account);
        }
    }
}