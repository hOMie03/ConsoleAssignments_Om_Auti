using TicketTango.Models;
using TicketTango.ViewModels;

namespace TicketTango.Service
{
    public interface IUserService
    {
        Task<User> Login(string email, string pswd);
    }
}
