using CuentaBancariaMultiUsuario._2.Business.IServices;
using CuentaBancariaMultiUsuario._3.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._1.Presentation.Screens
{
    public class Option2Screen
    {
        private readonly IBankAccountService _bankAccountService;

        public Option2Screen(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public void Start()
        {
            Console.Write("List of all accounts: ");

            List<BankAccount> list = _bankAccountService.GetList();

            foreach (BankAccount ba in list)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"* AccountId: {ba.AccountNumber}");
                Console.WriteLine($"* AccountPin: {ba.PinNumber}");
            }
        }
    }
}
