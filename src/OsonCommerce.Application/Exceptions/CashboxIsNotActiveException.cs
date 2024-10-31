namespace OsonCommerce.Application.Exceptions
{
    public class CashboxIsNotActiveException : Exception
    {
        public CashboxIsNotActiveException(string message) : base(message)
        { }
    }
}