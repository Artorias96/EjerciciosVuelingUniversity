using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscutting.CustomExceptions
{
    public class NotExistingElement : Exception
    {
        public NotExistingElement(string message) : base(message)
        {
            
        }
    }
}
