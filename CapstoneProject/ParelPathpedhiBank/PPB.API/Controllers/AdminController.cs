using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPB.Application.Features.AccountFeature.Query.GetAllAccounts;
using PPB.Application.Features.TransactionFeature.Query.GetAllTransactions;
using PPB.Application.Interfaces.Identity;

namespace PPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IAuthService _authService;
        //Constructor Dependency
        public AdminController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }
        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactionsAsync()
        {
            var allTransactions = await _mediator.Send(new GetAllTransactionsQuery());
            return Ok(allTransactions);
        }
        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccountsAsync()
        {
            var allAccounts = await _mediator.Send(new GetAllAccountsQuery());
            return Ok(allAccounts);
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var allUsers = await _authService.GetAllUsers();
            return Ok(allUsers);
        }
    }
}
