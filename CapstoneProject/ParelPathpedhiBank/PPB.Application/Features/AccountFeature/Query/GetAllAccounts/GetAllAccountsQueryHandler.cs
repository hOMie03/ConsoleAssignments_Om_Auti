using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Interfaces;
using PPB.Domain.Models;

namespace PPB.Application.Features.AccountFeature.Query.GetAllAccounts
{
    internal class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Account>>
    {
        readonly IAccountRepository _accountRepository;
        // Constructor
        public GetAllAccountsQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var allAccounts = await _accountRepository.GetAllAccounts();
            return allAccounts;
        }
    }
}
