using CuentaBancariaMultiUsuario._2.Business.IServices;
using CuentaBancariaMultiUsuario._5.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._1.Presentation.Screens
{
    public class Option1Screen
    {
        private readonly IBankAccountService _bankAccountService;

        public Option1Screen(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public void Start()
        {
            Console.Write("Please enter desired money amount to add to current account balance: ");
            string incomeAsString = Console.ReadLine();
            Console.WriteLine();

            (bool isParseable, decimal parsedIncome) = new ParsingUtils().TryParseDecimalValue(incomeAsString);

            if (isParseable)
            {
                decimal? updatedBalance = _bankAccountService.MoneyIncome(parsedIncome);
                if (!updatedBalance.HasValue)
                {
                    Console.WriteLine($"Value '{incomeAsString}' is not a valid income, because it's not a positive number");
                }
                else
                {
                    Console.WriteLine($"Your money income has been correctly processed. New account balance: {updatedBalance:0.##}");
                }
            }
        }
    }
}
