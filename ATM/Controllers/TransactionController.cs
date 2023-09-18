namespace ATM.Controllers
{
    using Core.Features.Transaction.GetTransactions;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetTransactions(string cardNumber)
        {
            var request = new GetTransactionsRequest { CardNumber = cardNumber };
            var response = await _mediator.Send(request);

            var transactions = response.Transactions.ToList();

            var paginatedTransactions = PaginationHelper.Paginate(transactions);

            var paginatedResponses = paginatedTransactions
                .Select((pageItems, pageIndex) => new PaginatedTransactionsResponse
                {
                    CurrentPage = pageIndex + 1,
                    TotalPages = paginatedTransactions.Count,
                    Transactions = pageItems
                })
                .ToList();

            return Ok(paginatedResponses);
        }
    }

}