using CuentaBancariaMultiUsuario._3.Domain;
using CuentaBancariaMultiUsuario._3.Domain.IRepositories;
using CuentaBancariaMultiUsuario._4.Infrastructure_Data.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario.Infrastructure_Data
{
    public class BankAccountRepository : IBankAccountRepository
    {
        public List<BankAccount> GetBankAccountList()
        {
            BankAccountMultiuserEntities3 dbConnection = new BankAccountMultiuserEntities3();

            List<BankAccounts> bankAccountsListFromDB = dbConnection.BankAccounts.ToList();

            List<BankAccount> result = new List<BankAccount>();
            foreach(BankAccounts bankAccountFromDB in bankAccountsListFromDB)
            {
                result.Add(new BankAccount
                {
                    AccountNumber = bankAccountFromDB.AccountId,
                    PinNumber = int.Parse(bankAccountFromDB.AccountPin),
                    Balance = bankAccountFromDB.Money,
                    Movements = bankAccountFromDB.Movements.ToList().Select(x => new Movement
                    {
                        Amount = x.Amount,
                        Timestamp = x.Datetime
                    }).ToList()
                });

            }
            return result;  
        }
        

        public void SetBankAccount(BankAccounts newDataForBankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
