namespace PPB.Exceptions
{
    public class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException(string message) : base(message) { }
    }
}
