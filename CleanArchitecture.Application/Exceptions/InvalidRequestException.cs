using System;

namespace CleanArchitecture.Application.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException()
        {
            throw new Exception();
        }

        public InvalidRequestException(string message)
        {
            throw new Exception(message);
        }
    }
}