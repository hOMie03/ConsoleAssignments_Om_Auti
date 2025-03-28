using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Domain.Models;

namespace PPB.Application.Features.TransactionFeature.Query.GetTransactionsByAccID
{
    public record GetTransactionsByAccIDQuery(int accID) : IRequest<IEnumerable<Transaction>>;
}
