using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._3.Domain
{
    public class Movement
    {
        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
