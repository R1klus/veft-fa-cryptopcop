using System;

namespace Cryptocop.Software.API.Repositories.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException() : base("Invalid Login Credentials")
        {
            
        }

        public InvalidLoginException(string message) : base(message)
        {
            
        }

        public InvalidLoginException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}