using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._3.Domain
{
    public class BankAccount
    {

        public string AccountNumber { get; set; } 
        public int PinNumber { get; set; }
        public decimal Balance { get; set; }
        public List<Movement> Movements { get; set; }

        public void MoneyIncome(decimal income)
        {
            Balance += income;
            Movements.Add(new Movement { Amount = income, Timestamp = DateTime.Now });
        }

        public void MoneyOutcome(decimal outcome)
        {
            Balance -= outcome;
            Movements.Add(new Movement { Amount = -outcome, Timestamp = DateTime.Now });
        }
    }
}
