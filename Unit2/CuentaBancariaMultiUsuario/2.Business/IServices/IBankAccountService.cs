using CuentaBancariaMultiUsuario._3.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._2.Business.IServices
{
    public interface IBankAccountService
    {

        decimal? MoneyIncome(decimal income);
        List<BankAccount> GetList();
    }
}
