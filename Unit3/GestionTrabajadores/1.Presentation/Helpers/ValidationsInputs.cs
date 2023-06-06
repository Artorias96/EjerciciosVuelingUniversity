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
        public string ValidateStringContent(string str)
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

        public string ValidateString(string msg)
        {

            Console.WriteLine(msg);

            string input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Error, please introduce the information");
            }
            return input;

        }

        public int ValidateInt(string msg)
        {
            Console.WriteLine(msg);
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 0)
            {
                Console.WriteLine("Error, please introduce the information");
            }
            return input;

        }

        public (bool, DateTime) ValidateDateTime(string birthday)
        {
            DateTime dt;
            bool isValidate = false;
            if (DateTime.TryParseExact(birthday, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                isValidate = true;
            }
            return(isValidate, dt);
        }

   
    }
}
