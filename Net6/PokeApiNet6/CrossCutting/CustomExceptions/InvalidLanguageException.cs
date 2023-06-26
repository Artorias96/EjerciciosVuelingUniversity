using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomExceptions
{
    public class InvalidLanguageException : Exception
    {
        public InvalidLanguageException(string message) : base(message)
        {
            
        }
    }
}
