using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Interfaces;

namespace PPB.Application.Features.AccountFeature.Command.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, bool>
    {
        readonly IAccountRepository _accountRepository;
        public DeleteAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }
        public Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var deletingAcc = _accountRepository.DeleteAccountAsync(request.userID, request.accNo);
            return deletingAcc;
        }
    }
}
