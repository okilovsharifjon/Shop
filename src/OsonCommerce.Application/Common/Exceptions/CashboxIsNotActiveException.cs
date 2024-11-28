namespace OsonCommerce.Application.Common.Exceptions;

public class CashboxIsNotActiveException : Exception
{
    public CashboxIsNotActiveException(string message) : base(message)
    { }
}