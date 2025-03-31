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

namespace PPB.Application.Features.TransactionFeature.Command.AddTransaction
{
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, TransactionDTO>
    {
        readonly ITransactionRepository _transactionRepository;
        public AddTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;

        }
        public Task<TransactionDTO> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transact = _transactionRepository.AddTransactionAsync(request.newTransaction);
            return transact;
        }
    }
}
