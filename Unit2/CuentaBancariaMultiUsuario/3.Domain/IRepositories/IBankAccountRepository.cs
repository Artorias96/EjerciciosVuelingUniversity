using CuentaBancariaMultiUsuario._4.Infrastructure_Data.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._3.Domain.IRepositories
{
    public interface IBankAccountRepository
    {

        List<BankAccount> GetBankAccountList();
        void SetBankAccount(BankAccounts newDataForBankAccount);
    }
}
