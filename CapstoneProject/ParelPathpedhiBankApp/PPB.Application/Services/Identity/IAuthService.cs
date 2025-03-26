using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Application.Model.Identity;

namespace PPB.Application.Services.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
    }
}
