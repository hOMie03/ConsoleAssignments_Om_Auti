using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPB.Application.Features.TransactionFeature.Command.AddTransaction;
using PPB.Application.Features.TransactionFeature.Query.GetAllTransactions;
using PPB.Application.Features.TransactionFeature.Query.GetTransactionsByAccID;
using PPB.Application.Models;
using PPB.Domain.Models;

namespace PPB.API.Controllers
{
    //[Authorize(Roles = "Administrator")]
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
        [HttpPost("DoTransaction")]
        public async Task<IActionResult> AddTransactionAsync(TransactionDTO newTransaction)
        {
            var newTransact = await _mediator.Send(new AddTransactionCommand(newTransaction));
            return Ok(newTransact);
        }
    }
}
