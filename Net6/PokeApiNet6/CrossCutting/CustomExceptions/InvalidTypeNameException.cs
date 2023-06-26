using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomExceptions
{
    public class InvalidTypeNameException : Exception
    {
        public InvalidTypeNameException(string message) : base(message)
        {

        }
    }
}
