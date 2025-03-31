using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Interfaces;
using PPB.Application.Models;
using PPB.Domain.Models;

namespace PPB.Application.Features.AccountFeature.Command.AddAccount
{
    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, AddAccountDTO>
    {
        readonly IAccountRepository _accountRepository;
        public AddAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }
        public Task<AddAccountDTO> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var acc = _accountRepository.AddAccountAsync(request.newAccount);
            return acc;
        }
    }
}
