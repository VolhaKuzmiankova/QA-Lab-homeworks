using System;

namespace ExceptionsHomework.Exceptions
{
    public class PhoneUnavailableException : Exception
    {
        public PhoneUnavailableException()
        {
        }

        public PhoneUnavailableException(string? message) : base(message)
        {
            
        }

        public PhoneUnavailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}