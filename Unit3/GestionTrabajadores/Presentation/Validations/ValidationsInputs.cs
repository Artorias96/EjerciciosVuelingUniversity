using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionTrabajadores.Bussiness.Verifications
{
    public class ValidationsInputs
    {
        public string ValidateStringInput(string str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z]+$"))
            {
                return str;

            }
            else
            {
                Console.WriteLine("Please introduce letters.");
                return "";                
            }
            
        }
    }
}
