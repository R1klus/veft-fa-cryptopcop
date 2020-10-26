using System;

namespace Cryptocop.Software.API.Repositories.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException()
        {
            
        }
        
        public InvalidLoginException(string name)
            : base("Invalid login credentials")
        {

        }
    }
}