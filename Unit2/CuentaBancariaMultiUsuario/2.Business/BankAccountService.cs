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
            return _bankAccountRepository.GetList();
        }

        public void CreateBA()
        {
            BankAccount bankAccount = new BankAccount
            {
                Balance = 55555,
                AccountNumber = "69",
                PinNumber = 69,
                Movements = new List<Movement> { new Movement { Amount = 55555, Timestamp = DateTime.Now } }
                
            };

            _bankAccountRepository.CreateBankAccount(bankAccount);
        }

        public decimal? MoneyIncome(decimal income)
        {
            decimal? result = null;

            return result;
        }
    }
}
