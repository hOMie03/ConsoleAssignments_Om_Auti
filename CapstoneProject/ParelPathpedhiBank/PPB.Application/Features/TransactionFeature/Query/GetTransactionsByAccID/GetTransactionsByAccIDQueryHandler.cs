using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Features.TransactionFeature.Query.GetAllTransactions;
using PPB.Application.Interfaces;
using PPB.Domain.Models;

namespace PPB.Application.Features.TransactionFeature.Query.GetTransactionsByAccID
{
    internal class GetTransactionsByAccIDQueryHandler : IRequestHandler<GetTransactionsByAccIDQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        // Constructor
        public GetTransactionsByAccIDQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetTransactionsByAccIDQuery request, CancellationToken cancellationToken)
        {
            var allTransactByAID = await _transactionRepository.GetTransactionsByAccID(request.accID);
            return allTransactByAID;
        }
    }
}
