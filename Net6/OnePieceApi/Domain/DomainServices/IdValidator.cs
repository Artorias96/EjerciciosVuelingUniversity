using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices
{
    public class IdValidator
    {
        public static bool Validate(string idToValidate)
        {
            return idToValidate.Length == 2 && idToValidate.ToUpper() == idToValidate;
        }
    }
}
