using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Features.AccountFeature.Command.AddAccount;
using PPB.Application.Interfaces;
using PPB.Application.Models;
using PPB.Domain.Models;

namespace PPB.Application.Features.AccountFeature.Command.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountDTO>
    {
        readonly IAccountRepository _accountRepository;
        public UpdateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }
        public Task<UpdateAccountDTO> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var acc = _accountRepository.UpdateAccountAsync(request.id, request.account);
            return acc;
        }
    }
}
