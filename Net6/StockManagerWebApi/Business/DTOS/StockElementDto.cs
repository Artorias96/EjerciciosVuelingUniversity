using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.DTOS
{
    public class StockElementDto
    {
        public string? Clue { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        

        public bool ValidateName(string name)
        {
            if (name.Count() > 100)
            {
                return false;
            }
            return true;
        }

        public bool ValidateDescription(string description)
        {
            if (description.Count() > 200)
            {
                return false;
            }
            return true;
        }
    }
}
