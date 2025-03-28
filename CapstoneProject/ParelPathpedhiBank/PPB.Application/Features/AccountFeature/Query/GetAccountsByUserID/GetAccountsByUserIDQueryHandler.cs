using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Features.AccountFeature.Query.GetAllAccounts;
using PPB.Application.Interfaces;
using PPB.Domain.Models;

namespace PPB.Application.Features.AccountFeature.Query.GetAccountsByUserID
{
    internal class GetAccountsByUserIDQueryHandler : IRequestHandler<GetAccountsByUserIDQuery, IEnumerable<Account>>
    {
        readonly IAccountRepository _accountRepository;
        // Constructor
        public GetAccountsByUserIDQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IEnumerable<Account>> Handle(GetAccountsByUserIDQuery request, CancellationToken cancellationToken)
        {
            var allAccounts = await _accountRepository.GetAccountsByUserID(request.userID);
            return allAccounts;
        }
    }
}
