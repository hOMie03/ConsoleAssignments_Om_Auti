using TicketTango.Models;

namespace TicketTango.Service
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task<int> AddEventAsync(Event eventEntity);
        Task<int> DeleteEventAsync(int id);
        Task<int> UpdateEventAsync(Event eventEntity);

        Task<IEnumerable<Event>> SearchEventAsync(string searched);
        Task<IEnumerable<Event>> GetAllActiveEventsAsync();
    }
}
