using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomExceptions
{
    public class WrongFormatException : Exception
    {
        public WrongFormatException(string message) : base(message)
        {

        }
    }
}
