using TicketTango.Exceptions;
using TicketTango.Models;
using TicketTango.Repository;

namespace TicketTango.Service
{
    public class TicketBookingService : ITicketBookingService
    {
        readonly ITicketBookingRepository _tbRepository;
        #region Repo Constructor
        public TicketBookingService(ITicketBookingRepository tbRepository)
        {
            _tbRepository = tbRepository;
        }
        #endregion

        public async Task<int> BookTicketAsync(int userID, int eventID, int quantity)
        {
            return await _tbRepository.BookTicketAsync(userID, eventID, quantity);
        }
        public async Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(int userID)
        {
            var foundTix = await _tbRepository.GetBookingsByUserIdAsync(userID);
            if (foundTix == null || foundTix.Count() == 0)
            {
                throw new BookingNotFoundException($"Looks a bit empty? No bookings done till now!");
            }
            return foundTix;
        }
    }
}
