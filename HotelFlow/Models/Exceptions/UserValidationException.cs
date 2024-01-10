namespace HotelFlow.Models.Exceptions
{
    public class UserValidationException : IValidationException
    {
        public UserValidationException(string message) 
        {
            Message = message;
        }

        public UserValidationException(string message, Exception innerException)
        {
            Message = message;
            InnerException = innerException;
        }

        public string Message { get; }

        public Exception InnerException { get; }
    }
}
