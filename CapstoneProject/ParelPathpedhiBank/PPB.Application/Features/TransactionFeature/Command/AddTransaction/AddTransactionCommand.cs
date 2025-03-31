using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Models;
using PPB.Domain.Models;

namespace PPB.Application.Features.TransactionFeature.Command.AddTransaction
{
    public record AddTransactionCommand(TransactionDTO newTransaction) : IRequest<TransactionDTO>;
}
