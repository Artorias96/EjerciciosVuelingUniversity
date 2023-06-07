using CuentaBancariaMultiUsuario._2.Business.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._1.Presentation.Screens
{
    public class Option3Screen
    {
        private readonly IBankAccountService _bankAccountService;

        public Option3Screen(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public void Start()
        {
            _bankAccountService.CreateBA();
        }
    }
}
