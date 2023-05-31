using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario
{
    internal class Money
    {
        private decimal balance = 0;
        List<decimal> AllMovements = new List<decimal>();
        List<decimal> MovementsDeposit = new List<decimal>();
        List<decimal> MovementsWithdraw = new List<decimal>();

        public void Deposit(decimal d)
        {
            balance += d;
            AllMovements.Add(d);
            MovementsDeposit.Add(d);
            Console.WriteLine("\n");
        }

        public void Withdraw(decimal d)
        {
            balance -= d;
            AllMovements.Add(d);
            MovementsWithdraw.Add(d);
        }

        public List<decimal> getAllMovements()
        {
            return AllMovements;
        }

        public List<decimal> getDeposits()
        {
            return MovementsDeposit;
        }

        public List<decimal> getWithdraws()
        {
            return MovementsWithdraw;
        }

        public decimal getBalance()
        {
            return balance;
        }
    }
}
