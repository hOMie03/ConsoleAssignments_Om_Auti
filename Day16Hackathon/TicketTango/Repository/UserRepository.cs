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

        public async Task<int> Register(User user)
        {
            await _ttDBContext.Users.AddAsync(user);
            return await _ttDBContext.SaveChangesAsync();
        }

        // For Admin User Controls
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _ttDBContext.Users.ToListAsync();
        }
        public async Task<int> PromoteToEventOrgAsync(int userID)
        {
            User userFound = await _ttDBContext.Users.FirstOrDefaultAsync(u => u.ID == userID);
            if (userFound != null)
            {
                userFound.Roles = Roles.EventOrganizer;
                _ttDBContext.Users.Update(userFound);
            }
            return await _ttDBContext.SaveChangesAsync();
        }
    }
}
