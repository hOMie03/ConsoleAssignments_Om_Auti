using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketTango.Context;
using TicketTango.Models;
using TicketTango.ViewModels;

namespace TicketTango.Repository
{
    public class TicketBookingRepository : ITicketBookingRepository
    {
        readonly TicketTangoDBContext _ttDBContext;
        readonly IEventRepository _eventRepository;

        #region Constructor Dependency
        public TicketBookingRepository(TicketTangoDBContext ttdbc, IEventRepository eventRepository)
        {
            _ttDBContext = ttdbc;
            _eventRepository = eventRepository;
        }
        #endregion

        public async Task<int> BookTicketAsync(int userID, int eventID, int quantity)
        {
            var eventDetails = await _eventRepository.GetEventByIdAsync(eventID);
            decimal totalCost = eventDetails.TicketPrice * quantity;
            var tixAdd = new TicketBooking() {
                UserID = userID,
                Event = eventDetails,
                Quantity = quantity,
                TotalCost = totalCost,
                BookingDate = DateTime.Now,
                Status = true
            };
            await _ttDBContext.TicketBookings.AddAsync(tixAdd);
            return await _ttDBContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(int userID)
        {
            var bookings = await _ttDBContext.TicketBookings.Where(t => t.UserID == userID).ToListAsync();
            return bookings;
        }
    }
}
