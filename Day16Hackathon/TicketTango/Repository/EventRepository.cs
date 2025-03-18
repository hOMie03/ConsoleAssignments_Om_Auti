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
            return await _ttDBContext.Events.ToListAsync();
        }
    }
}
