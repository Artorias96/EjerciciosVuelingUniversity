using Business.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace StockManager.WebApi.Helpers
{
    public class ValidationHelper : IValidationService
    {
        public bool ValidateName(string name) 
        {
        if(name.Count() > 100)
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

        public bool ValidateIdFormat(string id) 
        {
            if (id.Contains("ñ"))
            {
                return false;
            }

            string validateString = "^[0-9]{3}[A-Za-z]{3}$";

            if (Regex.IsMatch(id, validateString))
            {
                return true;
            }
            else
            {
                return false;
            }

            return true;

        }
    }
}