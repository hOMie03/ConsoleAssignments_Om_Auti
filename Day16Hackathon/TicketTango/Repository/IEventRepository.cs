using TicketTango.Models;

namespace TicketTango.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        //Task<Event> GetEventByIdAsync(int id);
        //Task AddEventAsync(Event eventEntity);
        //Task UpdateEventAsync(Event eventEntity);
        //Task DeleteEventAsync(int id);
    }
}
