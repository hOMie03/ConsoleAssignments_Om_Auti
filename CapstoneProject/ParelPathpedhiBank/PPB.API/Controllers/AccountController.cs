using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetBooksAsync()
        {
            var allBooks = await _mediator.Send(new GetAllAccountsQuery());
            return Ok(allBooks);
        }

    }
}
