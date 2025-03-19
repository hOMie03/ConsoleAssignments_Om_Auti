using TicketTango.Models;

namespace TicketTango.Repository
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string pswd);
        Task<int> Register(User user);
    }
}
