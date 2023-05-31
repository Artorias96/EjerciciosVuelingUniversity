using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string nameS, ageS, PinS, nameF, ageF, PinF, nameGrandf, ageGrandf, PinGrandF;
            string messageMenu = "Select one of the options \n 1. Show Values \n 2. Modify Values \n 3. Exit";

            Son son1 = new Son("Paco", "18", "6459", "Santiago", "43", "4915", "Eustaquio", "65", "3164");

            do
            {
                Console.WriteLine(messageMenu);

                string entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "1":

                        son1.ShowValues();
                        break;

                    case "2":

                        MethodModifyValues(out nameS, out ageS, out PinS, out nameF, out ageF, out PinF, out nameGrandf, out ageGrandf, out PinGrandF, son1);
                        break;

                    case "3":

                        exit = true;
                        Console.WriteLine();
                        break;
                }

            } while (!exit);
        }

        private static void MethodModifyValues(out string nameS, out string ageS, out string PinS, out string nameF, out string ageF, out string PinF, out string nameGrandf, out string ageGrandf, out string PinGrandF, Son son1)
        {
            Console.WriteLine("Introduce Son name: ");
            nameS = Console.ReadLine();
            Console.WriteLine("Introduce Son age: ");
            ageS = Console.ReadLine();
            Console.WriteLine("Introduce Son PIN: ");
            PinS = Console.ReadLine();
            Console.WriteLine("Introduce Father name: ");
            nameF = Console.ReadLine();
            Console.WriteLine("Introduce Father age: ");
            ageF = Console.ReadLine();
            Console.WriteLine("Introduce Father PIN: ");
            PinF = Console.ReadLine();
            Console.WriteLine("Introduce GrandFather name: ");
            nameGrandf = Console.ReadLine();
            Console.WriteLine("Introduce GrandFather age: ");
            ageGrandf = Console.ReadLine();
            Console.WriteLine("Introduce GrandFather PIN: ");
            PinGrandF = Console.ReadLine();

            son1.ModifyAllValues(nameS, ageS, PinS, nameF, ageF, PinF, nameGrandf, ageGrandf, PinGrandF);
            son1.ShowValues();
        }
    }
}
