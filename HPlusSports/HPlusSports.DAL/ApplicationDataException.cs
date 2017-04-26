using System;

namespace HPlusSports.DAL
{
    public class ApplicationDataException : Exception
    {
        public ApplicationDataException()
        {
        }

        public ApplicationDataException(string message) : base(message)
        {
        }

        public ApplicationDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}