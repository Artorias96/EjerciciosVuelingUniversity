using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomExceptions
{
    public class CannotSaveDataExceptions : Exception
    {
        public CannotSaveDataExceptions(string message) : base(message)
        {

        }
    }
}
