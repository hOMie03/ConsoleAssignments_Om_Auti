using TicketTango.Models;

namespace TicketTango.Service
{
    public interface ITicketBookingService
    {
        Task<IEnumerable<TicketBooking>> GetBookingsByUserIdAsync(int userID);
        Task<int> BookTicketAsync(int userID, int eventID, int quantity);

        Task<TicketBooking> GetTixByUserAndBookingIdAsync(int userID, int bookingID);
        Task<int> CancelBookingAsync(int bookingID);
    }
}
