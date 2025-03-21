using TicketTango.Models;

namespace TicketTango.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task<int> AddEventAsync(Event eventEntity);
        Task<int> UpdateEventAsync(Event eventEntity);
        Task<int> DeleteEventAsync(int id);

        Task<IEnumerable<Event>> SearchEventAsync(string searched);
        Task<IEnumerable<Event>> GetAllActiveEventsAsync();
    }
}
