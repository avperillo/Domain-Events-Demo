using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Services.Users
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException()
        {
        }

        public UserAlreadyExistException(string message) : base(message)
        {
        }

        public UserAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
