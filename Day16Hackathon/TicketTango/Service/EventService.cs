using TicketTango.Exceptions;
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
        public async Task<Event> GetEventByIdAsync(int id)
        {
            var foundEvent = await _eventRepository.GetEventByIdAsync(id);
            if (foundEvent == null)
            {
                throw new EventNotFoundException($"Event with {id} not found!");
            }
            return foundEvent;
        }
        public async Task<int> AddEventAsync(Event eventEntity)
        {
            return await _eventRepository.AddEventAsync(eventEntity);
        }
        public async Task<int> UpdateEventAsync(Event eventEntity)
        {
            return await _eventRepository.UpdateEventAsync(eventEntity);
        }
        public async Task<int> DeleteEventAsync(int id)
        {
            return await _eventRepository.DeleteEventAsync(id);
        }

        // Extras
        public async Task<IEnumerable<Event>> SearchEventAsync(string searched)
        {
            var foundEvent =  await _eventRepository.SearchEventAsync(searched);
            if (foundEvent.Count() > 0)
            {
                return foundEvent;
            }
            else
            {
                throw new EventNotFoundException(($"Uh-oh, no related event found!"));
            }
        }
        public async Task<IEnumerable<Event>> GetAllActiveEventsAsync()
        {
            return await _eventRepository.GetAllActiveEventsAsync();
        }
    }
}
