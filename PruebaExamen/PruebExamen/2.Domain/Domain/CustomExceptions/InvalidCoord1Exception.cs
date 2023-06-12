

using System;

namespace Domain.CustomExceptions
{
    public class InvalidCoord1Exception : Exception
    {
        public InvalidCoord1Exception(string message) : base (message)
        {
                
        }
    }
}
