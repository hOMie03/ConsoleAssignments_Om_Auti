using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPB.Application.Features.AccountFeature.Query.GetAccountsByUserID;
using PPB.Application.Features.AccountFeature.Query.GetAllAccounts;

namespace PPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMediator _mediator;
        //Constructor Dependency
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountsAsync()
        {
            var allAccounts = await _mediator.Send(new GetAllAccountsQuery());
            return Ok(allAccounts);
        }
        [HttpGet("{userID}")]
        public async Task<IActionResult> GetAccountsByUIDAsync(string userID)
        {
            var accByUID = await _mediator.Send(new GetAccountsByUserIDQuery(userID));
            return Ok(accByUID);
        }

    }
}
