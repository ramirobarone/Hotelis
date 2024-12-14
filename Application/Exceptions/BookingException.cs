using System.Runtime.Serialization;

namespace Application.Exceptions
{
    internal class BookingException : Exception
    {
        public BookingException()
        {
        }

        public BookingException(string? message) : base(message)
        {
        }

        public BookingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BookingException(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
