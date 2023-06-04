using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._1.Presentation.Helpers
{
    public class DataCoherency
    {
        public bool ValidateAge(DateTime dt)
        {
            int age = DateTime.Today.Year - dt.Year;
            if (DateTime.Today < dt.AddYears(age))
                age--;

            if (age <= 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
