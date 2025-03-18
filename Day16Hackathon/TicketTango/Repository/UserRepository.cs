using Microsoft.EntityFrameworkCore;
using TicketTango.Context;
using TicketTango.Models;

namespace TicketTango.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly TicketTangoDBContext _ttDBContext;

        #region Constructor Dependency
        public UserRepository(TicketTangoDBContext ttdbc)
        {
            _ttDBContext = ttdbc;
        }
        #endregion
        
        public async Task<User> Login(string email, string pswd)
        {
            var user = await _ttDBContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == pswd);
            return user;
        }
    }
}
