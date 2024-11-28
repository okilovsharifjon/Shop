namespace OsonCommerce.Application.Common.Exceptions;

public class ExistingDataException : Exception
{
    public ExistingDataException(string message) : base(message)
    { }
}
