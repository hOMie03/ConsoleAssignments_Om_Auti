using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Application.Model.Identity;
using PPB.Application.Services.Identity;

namespace PPB.Identity.Service
{
    public class AuthService : IAuthService
    {
        public Task<AuthResponse> Login(AuthRequest authRequest)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
