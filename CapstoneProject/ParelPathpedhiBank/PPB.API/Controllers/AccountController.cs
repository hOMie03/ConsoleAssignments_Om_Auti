using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPB.Application.Features.AccountFeature.Command.AddAccount;
using PPB.Application.Features.AccountFeature.Command.DeleteAccount;
using PPB.Application.Features.AccountFeature.Command.UpdateAccount;
using PPB.Application.Features.AccountFeature.Query.GetAccountsByUserID;
using PPB.Application.Features.AccountFeature.Query.GetAllAccounts;
using PPB.Application.Models;
using PPB.Domain.Models;

namespace PPB.API.Controllers
{
    //[Authorize(Roles = "Administrator")]
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
        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccountAsync(AddAccountDTO newAccount)
        {
            var newAcc = await _mediator.Send(new AddAccountCommand(newAccount));
            return Ok(newAcc);
        }
        [HttpPost("DeleteAccount")]
        public async Task<IActionResult> DeleteAccountAsync(string userID, int accID)
        {
            var deletingAcc = await _mediator.Send(new DeleteAccountCommand(userID, accID));
            return Ok(deletingAcc);
        }
        [HttpPost("UpdateAccount")]
        public async Task<IActionResult> UpdateAccountAsync(int id, UpdateAccountDTO account)
        {
            var updatingAcc = await _mediator.Send(new UpdateAccountCommand(id, account));
            return Ok(updatingAcc);
        }

    }
}
