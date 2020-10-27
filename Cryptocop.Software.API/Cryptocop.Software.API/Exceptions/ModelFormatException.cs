using System;

namespace Cryptocop.Software.API.Exceptions
{
    public class ModelFormatException : Exception
    {
        public ModelFormatException() : base("Model is not properly formatted.")
        {
            
        }

        public ModelFormatException(string message) : base(message)
        {
            
        }

        public ModelFormatException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}