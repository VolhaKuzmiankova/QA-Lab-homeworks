using System;
using System.Linq.Expressions;

namespace ExceptionsHomework.Exceptions
{
    public class PhoneNotFoundException : Exception
    {
        public PhoneNotFoundException()
        {
        }

        public PhoneNotFoundException(string? message) : base(message)
        {
        }

        public PhoneNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}