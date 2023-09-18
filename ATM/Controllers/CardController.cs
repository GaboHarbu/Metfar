namespace ATM.Controllers
{
    using Core.Features.WithdrawMoney;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("api/card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(string cardNumber, float amount)
        {
            var request = new WithdrawMoneyRequest { CardNumber = cardNumber, Amount = amount };
            var response = await _mediator.Send(request);

            return Ok(response); 
        }
    }
}