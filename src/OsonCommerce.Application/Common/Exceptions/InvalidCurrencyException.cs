namespace OsonCommerce.Application.Common.Exceptions;

public class InvalidCurrencyException : Exception
{
    public InvalidCurrencyException(string message) : base(message)
    { }
}
