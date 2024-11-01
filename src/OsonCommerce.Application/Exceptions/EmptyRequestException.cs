namespace OsonCommerce.Application.Exceptions
{
    public class EmptyRequestException : Exception
    {
        public EmptyRequestException(string message) : base(message)
        { }
    }
}