namespace TicketTango.Exceptions
{
    public class BookingNotFoundException : ApplicationException
    {
        public BookingNotFoundException(string message) : base(message) { }
    }
}
