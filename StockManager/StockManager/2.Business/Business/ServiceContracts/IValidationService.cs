using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IValidationService
    {
        bool ValidateName(string name);
        bool ValidateDescription(string description);
        bool ValidateIdFormat(string id);
    }
}
