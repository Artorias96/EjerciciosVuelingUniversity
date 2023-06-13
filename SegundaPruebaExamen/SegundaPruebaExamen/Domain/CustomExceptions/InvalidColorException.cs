using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomExceptions
{
    public class InvalidColorException : Exception
    {
        public InvalidColorException(string message) : base(message)
        {

        }
    }
}
