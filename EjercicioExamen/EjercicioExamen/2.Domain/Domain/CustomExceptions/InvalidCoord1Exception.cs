using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomExceptions
{
    public class InvalidCoord1Exception : Exception
    {
        public InvalidCoord1Exception(string message) : base(message)
        {

        }
    }
}
