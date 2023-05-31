using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario
{
    internal class Account
    {

        List<string> AccountNumber = new List<string>();
        List<int> AccountPin = new List<int>();



        public bool VerifyUser(string usuario, int clave)
        {

            AccountNumber.AddRange(new List<string>() { "98456ES", "12345ES", "67891ES" });
            AccountPin.AddRange(new List<int>() { 6498, 1234, 5678 });

            if (AccountNumber.Contains(usuario) && AccountPin.Contains(clave))
            {
                Console.WriteLine("Inicio De Sesion Correcto");
                return true;
            }
            else
            {
                Console.WriteLine("Cuenta erronea");
                return false;
            }
        }
    }
}
