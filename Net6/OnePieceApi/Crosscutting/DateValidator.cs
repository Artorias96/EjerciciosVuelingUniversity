using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscutting
{
    public class DateValidator
    {
        //public DateTime? ParseFromString(string dateAsString)
        //{

        //}

        public DateTime? ValidateDateFormat(string dateAsString)
        {
            DateTime? result = null;
            if (dateAsString.Length == 8 && dateAsString.All(c => char.IsDigit(c)))
            {
                DateTime? date;
                if (DateTime.TryParseExact(dateAsString, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    result = date;
                };
                
            }
            return result;
        }
    }
}
