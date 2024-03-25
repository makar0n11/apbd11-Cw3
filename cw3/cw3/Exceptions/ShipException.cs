namespace cw3.Exceptions;

public class ShipException : Exception
{
    public ShipException()
    {
    }

    public ShipException(string? message) : base(message)
    {
    }

    public ShipException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}