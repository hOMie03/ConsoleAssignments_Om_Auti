using TicketTango.Models;
using TicketTango.Repository;

namespace TicketTango.Service
{
    public class EventService : IEventService
    {
        readonly IEventRepository _eventRepository;
        #region Repo Constructor
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        #endregion
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }
    }
}
