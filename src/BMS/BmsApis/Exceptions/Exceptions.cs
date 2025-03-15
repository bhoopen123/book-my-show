namespace BmsApis.Exceptions
{
    public class SeatInShowNotAvailableException : Exception
    {
        public SeatInShowNotAvailableException(string message) : base(message)
        {

        }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}
