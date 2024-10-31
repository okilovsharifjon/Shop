namespace OsonCommerce.Application.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        { }
    }
}