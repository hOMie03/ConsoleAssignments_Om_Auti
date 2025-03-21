using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketTango.Context;
using TicketTango.Exceptions;
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
            eventDetails.AvailableSeats = eventDetails.AvailableSeats - quantity;
            _ttDBContext.Events.Update(eventDetails);
            return await _ttDBContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(int userID)
        {
            var bookings = await _ttDBContext.TicketBookings.Where(t => t.UserID == userID).ToListAsync();
            return bookings;
        }


        public async Task<TicketBooking> GetTixByUserAndBookingIdAsync(int userID, int bookingID)
        {
            var tixFound = await _ttDBContext.TicketBookings.FirstOrDefaultAsync(t => t.UserID == userID && t.ID == bookingID);
            return tixFound;
        }
        public async Task<int> CancelBookingAsync(int bookingID)
        {
            var tixFound = await _ttDBContext.TicketBookings.FirstOrDefaultAsync(t => t.ID == bookingID);
            var eventFound = await _eventRepository.GetEventByIdAsync(tixFound.EventID);
            if(tixFound.Status == true && eventFound.DateOfEvent > DateTime.Now)
            {
                _ttDBContext.TicketBookings.Remove(tixFound);

            }
            else
            {
                throw new BookingNotFoundException($"You are too late buddy {bookingID}");
            }
            eventFound.AvailableSeats = eventFound.AvailableSeats + tixFound.Quantity;
            _ttDBContext.Events.Update(eventFound);
            return await _ttDBContext.SaveChangesAsync();
        }
    }
}
