using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    internal class Son : Father
    {
        public string nameSon { get; set; }
        protected string ageSon { get; set; }
        private string PinNumberSon { get; set; }

        public Son(string nameS, string ageS, string pinNumberS, string nameF, string ageF, string pinNumberF, string nameGrandF, string ageGrandf, string pinNumberGrandf)
            : base(pinNumberF, pinNumberGrandf)
        {
            nameSon = nameS;
            ageSon = ageS;
            PinNumberSon = pinNumberS;
            nameFather = nameF;
            ageFather = ageF;
            nameGrandfather = nameGrandF;
            ageGrandfather = ageGrandf;
        }

        public override void ShowValues()
        {
            base.ShowValues();
            Console.WriteLine($"The name of the Son is {nameSon}");
            Console.WriteLine($"The age of the Son is {ageSon}");
            Console.WriteLine($"The Pin number of the Son is {PinNumberSon}");
        }

        public void ModifyAllValues(string nameS, string ageS, string pinNumberS, string nameF, string ageF, string pinNumberF, string nameGrandF, string ageGrandf, string pinNumberGrandf)
        {
            nameSon = nameS;
            ageSon = ageS;
            PinNumberSon = pinNumberS;
            nameGrandfather = nameF;
            ageGrandfather = ageF;
            nameGrandfather = nameGrandF;
            ageGrandfather = ageGrandf;
            base.ModifyValuesFather(pinNumberF, pinNumberGrandf);
        }
    }
}
