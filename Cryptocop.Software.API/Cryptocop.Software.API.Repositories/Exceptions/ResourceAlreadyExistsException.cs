using System;

namespace Cryptocop.Software.API.Repositories.Exceptions
{
    public class ResourceAlreadyExistsException : Exception
    {
        public ResourceAlreadyExistsException() : base("Resource already exists.")
        {
            
        }

        public ResourceAlreadyExistsException(string message) : base(message)
        {
            
        }

        public ResourceAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {
            
        }


    }
}