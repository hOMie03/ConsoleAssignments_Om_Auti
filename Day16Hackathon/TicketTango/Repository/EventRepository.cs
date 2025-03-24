using Microsoft.EntityFrameworkCore;
using TicketTango.Context;
using TicketTango.Models;

namespace TicketTango.Repository
{
    public class EventRepository : IEventRepository
    {
        readonly TicketTangoDBContext _ttDBContext;

        #region Constructor Dependency
        public EventRepository(TicketTangoDBContext ttdbc)
        {
            _ttDBContext = ttdbc;
        }
        #endregion
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _ttDBContext.Events.OrderBy(o => o.DateOfEvent).ToListAsync();
        }
        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _ttDBContext.Events.FirstOrDefaultAsync(b => b.ID == id);
        }
        public async Task<int> AddEventAsync(Event eventEntity)
        {
            await _ttDBContext.Events.AddAsync(eventEntity);
            return await _ttDBContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEventAsync(Event eventEntity)
        {
            Event event2Update = await _ttDBContext.Events.FirstOrDefaultAsync(b => b.ID == eventEntity.ID);
            event2Update.Name = eventEntity.Name;
            event2Update.Location = eventEntity.Location;
            event2Update.DateOfEvent = eventEntity.DateOfEvent;
            event2Update.AvailableSeats = eventEntity.AvailableSeats;
            event2Update.TicketPrice = eventEntity.TicketPrice;
            _ttDBContext.Events.Update(event2Update);
            return await _ttDBContext.SaveChangesAsync();
        }
        public async Task<int> DeleteEventAsync(int id)
        {
            var selectedEvent = await GetEventByIdAsync(id);
            _ttDBContext.Events.Remove(selectedEvent);
            return await _ttDBContext.SaveChangesAsync();
        }

        // Extras
        public async Task<IEnumerable<Event>> SearchEventAsync(string searched)
        {
            var foundEvent = await _ttDBContext.Events.Where(b => b.Name.Contains(searched) || b.Location.Contains(searched)).ToListAsync();
            return foundEvent;
        }
        public async Task<IEnumerable<Event>> GetAllActiveEventsAsync()
        {
            return await _ttDBContext.Events.Where(b => b.DateOfEvent > DateTime.Now).OrderBy(o => o.DateOfEvent).ToListAsync();
        }
    }
}
