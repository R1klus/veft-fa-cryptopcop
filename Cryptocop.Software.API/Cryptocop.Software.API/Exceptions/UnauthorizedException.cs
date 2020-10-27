using System;

namespace Cryptocop.Software.API.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("JWT token provided is invalid.")
        {
            
        }

        public UnauthorizedException(string message) : base(message)
        {
            
        }

        public UnauthorizedException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}