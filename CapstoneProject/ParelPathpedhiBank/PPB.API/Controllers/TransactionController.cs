using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPB.Application.Features.AccountFeature.Query.GetAllAccounts;
using PPB.Application.Features.TransactionFeature.Query.GetAllTransactions;
using PPB.Application.Features.TransactionFeature.Query.GetTransactionsByAccID;

namespace PPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        readonly IMediator _mediator;
        //Constructor Dependency
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionsAsync()
        {
            var allTransactions = await _mediator.Send(new GetAllTransactionsQuery());
            return Ok(allTransactions);
        }
        
        [HttpGet("{accID}")]
        public async Task<IActionResult> GetTransactionsByAccIDAsync(int accID)
        {
            var allTransactionsByAID = await _mediator.Send(new GetTransactionsByAccIDQuery(accID));
            return Ok(allTransactionsByAID);
        }
    }
}
