using System;
using System.Runtime.Serialization;

namespace Demo.Application.Services.Users
{
    [Serializable]
    public class EmailAlreadyExistException : Exception
    {
        public EmailAlreadyExistException()
        {
        }

        public EmailAlreadyExistException(string message) : base(message)
        {
        }

        public EmailAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
