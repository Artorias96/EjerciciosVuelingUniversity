using CuentaBancariaMultiUsuario._2.Business.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._1.Presentation.Screens
{
    public class MainMenuScreen
    {
        private string option;
        private readonly IBankAccountService _bankAccountService;
        private readonly Option1Screen _option1Screen;
        private readonly Option2Screen _option2Screen;

        public MainMenuScreen(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
            _option1Screen = new Option1Screen(_bankAccountService);
            _option2Screen = new Option2Screen(_bankAccountService);
        }

        public void Start()
        {
            do
            {
                ShowMenuAndGetOption();
                ProcessSelectedOption();
            } while (option != "7");
        }

        private void ShowMenuAndGetOption()
        {
            Console.WriteLine("1 - Money income");
            Console.WriteLine("2 - List accounts");
            Console.WriteLine("7 - Exit");
            Console.Write("Select option: ");
            option = Console.ReadLine();
        }

        private void ProcessSelectedOption()
        {
            switch (option)
            {
                case "1":
                    _option1Screen.Start();
                    break;
                case "2":
                    _option2Screen.Start();
                    break;
            }
        }
    }
}
