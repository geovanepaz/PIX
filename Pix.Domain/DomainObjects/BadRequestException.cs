using System;
using System.Runtime.Serialization;

namespace Pix.Domain.DomainObjects
{
    public class BadRequestException : Exception
    {
        public readonly object Arguments;

        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BadRequestException(string message, object arguments = null) : base(message) => Arguments = arguments;

        public BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
