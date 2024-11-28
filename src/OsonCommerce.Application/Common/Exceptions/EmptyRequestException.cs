namespace OsonCommerce.Application.Common.Exceptions;

public class EmptyRequestException : Exception
{
    public EmptyRequestException(string message) : base(message)
    { }
}