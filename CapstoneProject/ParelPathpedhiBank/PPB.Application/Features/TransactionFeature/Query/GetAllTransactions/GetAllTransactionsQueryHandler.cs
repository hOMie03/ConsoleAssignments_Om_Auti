using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Features.AccountFeature.Query.GetAllAccounts;
using PPB.Application.Interfaces;
using PPB.Domain.Models;

namespace PPB.Application.Features.TransactionFeature.Query.GetAllTransactions
{
    internal class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        // Constructor
        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var allTransactions = await _transactionRepository.GetAllTransactions();
            return allTransactions;
        }
    }
}
