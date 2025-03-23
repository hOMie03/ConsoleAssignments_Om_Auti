namespace TicketTango.Exceptions
{
    public class EventNotFoundException : ApplicationException
    {
        public EventNotFoundException(string message) : base(message) { }
    }
}