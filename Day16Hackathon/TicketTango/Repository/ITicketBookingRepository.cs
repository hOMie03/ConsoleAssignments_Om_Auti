using TicketTango.Models;

namespace TicketTango.Repository
{
    public interface ITicketBookingRepository
    {
        Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(int userID);
        Task<int> BookTicketAsync(int userID, int eventID, int quantity);

        Task<TicketBooking> GetTixByUserAndBookingIdAsync(int userID, int bookingID);
        Task<int> CancelBookingAsync(int bookingId);
    }
}
