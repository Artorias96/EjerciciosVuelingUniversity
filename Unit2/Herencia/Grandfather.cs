using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    internal class Grandfather
    {
        public string nameGrandfather { get; set; }
        protected string ageGrandfather { get; set; }
        private string PinNumberGrandfather { get; set; }

        public Grandfather(string pinNumber)
        {
            PinNumberGrandfather = pinNumber;
        }

        public virtual void ShowValues()
        {
            Console.WriteLine($"The name of the GrandFather is {nameGrandfather}");
            Console.WriteLine($"The age of the GrandFather is {ageGrandfather}");
            Console.WriteLine($"The Pin number of the GrandFather is {PinNumberGrandfather}");

        }
        public void ModifyValuesGrandfather(string pinNumberGrandf)
        {
            PinNumberGrandfather = pinNumberGrandf;
        }




    }
}
