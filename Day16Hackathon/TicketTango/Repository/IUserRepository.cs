using TicketTango.Models;

namespace TicketTango.Repository
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string pswd);
    }
}
