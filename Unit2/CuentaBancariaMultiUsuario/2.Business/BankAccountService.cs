using CuentaBancariaMultiUsuario._2.Business.IServices;
using CuentaBancariaMultiUsuario._3.Domain;
using CuentaBancariaMultiUsuario._3.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._2.Business
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public List<BankAccount> GetList()
        {
            return _bankAccountRepository.GetBankAccountList();
        }

        public decimal? MoneyIncome(decimal income)
        {
            decimal? result = null;

            return result;
        }
    }
}
