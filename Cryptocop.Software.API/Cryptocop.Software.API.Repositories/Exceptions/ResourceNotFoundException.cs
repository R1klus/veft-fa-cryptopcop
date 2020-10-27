using System;

namespace Cryptocop.Software.API.Repositories.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base("Entity not found")
        {
            
        }
        public ResourceNotFoundException(string message) : base(message)
        {
            
        }
        public ResourceNotFoundException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}