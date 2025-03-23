using TicketTango.Models;
using TicketTango.ViewModels;

namespace TicketTango.Service
{
    public interface IUserService
    {
        Task<User> Login(string email, string pswd);
        Task<int> Register(User user);

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<int> PromoteToEventOrgAsync(int userID);
    }
}
