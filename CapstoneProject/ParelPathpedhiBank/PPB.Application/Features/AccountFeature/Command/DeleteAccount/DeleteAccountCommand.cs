using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PPB.Application.Features.AccountFeature.Command.DeleteAccount
{
    public record DeleteAccountCommand(string userID, int accNo) : IRequest<bool>;
}
