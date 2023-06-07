using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._5.CrossCutting
{
    public class ParsingUtils
    {
        public (bool, decimal) TryParseDecimalValue(string stringToParse)
        {
            string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            bool isParseable = decimal.TryParse(stringToParse.Replace(".", decimalSeparator).Replace(",", decimalSeparator), out decimal parsedDecimal);
            return (isParseable, parsedDecimal);
        }
    }
}
