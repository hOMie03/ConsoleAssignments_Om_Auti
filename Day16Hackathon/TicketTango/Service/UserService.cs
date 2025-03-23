using TicketTango.Models;
using TicketTango.Repository;
using TicketTango.ViewModels;

namespace TicketTango.Service
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        #region Repo Constructor
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion
        
        public async Task<User> Login(string email, string pswd)
        {
            var user = await _userRepository.Login(email, pswd);
            return user;
        }
        public async Task<int> Register(User user)
        {
            return await _userRepository.Register(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<int> PromoteToEventOrgAsync(int userID)
        {
            var promoteCount = await _userRepository.PromoteToEventOrgAsync(userID);
            return promoteCount;
        }
    }
}
