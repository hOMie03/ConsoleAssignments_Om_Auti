using TicketTango.Models;

namespace TicketTango.Service
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
    }
}
