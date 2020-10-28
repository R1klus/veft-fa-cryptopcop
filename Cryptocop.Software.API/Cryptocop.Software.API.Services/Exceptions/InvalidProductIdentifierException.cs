using System;

namespace Cryptocop.Software.API.Services.Exceptions
{
    public class InvalidProductIdentifierException : Exception
    {
        public InvalidProductIdentifierException() : base("Invalid product identifier.")
        {
            
        }

        public InvalidProductIdentifierException(string message) : base(message)
        {
            
        }

        public InvalidProductIdentifierException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}