using TicketTango.Models;

namespace TicketTango.Repository
{
    public interface ITicketBookingRepository
    {
        Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(int userId);
        Task BookTicketAsync(int userId, int eventId, int quantity);
        Task CancelBookingAsync(int bookingId);
    }
}
