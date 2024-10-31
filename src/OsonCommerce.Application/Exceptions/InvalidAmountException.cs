namespace OsonCommerce.Application.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message)
        { }
    }
}