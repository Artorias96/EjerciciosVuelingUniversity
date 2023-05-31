using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    internal class Father : Grandfather
    {
        public string nameFather { get; set; }
        protected string ageFather { get; set; }
        private string PinNumberFather { get; set; }

        public Father(string pinNumberFather, string pinNumberGrandf) : base(pinNumberGrandf)
        {
            PinNumberFather = pinNumberFather;
        }

        public override void ShowValues()
        {
            base.ShowValues();
            Console.WriteLine($"The name of the Father is {nameFather}");
            Console.WriteLine($"The age of the Father is {ageFather}");
            Console.WriteLine($"The Pin number of the Father is {PinNumberFather}");
        }

        public void ModifyValuesFather(string pinNumberF, string pinNumberGrandf)
        {
            base.ModifyValuesGrandfather(pinNumberGrandf);
            PinNumberFather = pinNumberF;
        }
    }
}
