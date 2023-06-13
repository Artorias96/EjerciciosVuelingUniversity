using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomExceptions
{
    public class InvalidIntException : Exception
    {
        public InvalidIntException(string message) : base(message)
        {

        }
    }
}
