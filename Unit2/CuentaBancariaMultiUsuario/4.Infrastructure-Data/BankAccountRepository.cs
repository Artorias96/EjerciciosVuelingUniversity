using CuentaBancariaMultiUsuario._3.Domain;
using CuentaBancariaMultiUsuario._3.Domain.IRepositories;
using CuentaBancariaMultiUsuario._4.Infrastructure_Data.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario.Infrastructure_Data
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly BankAccountMultiuserEntities3 _dbConnection;

        public BankAccountRepository()
        {
            _dbConnection = new BankAccountMultiuserEntities3();
        }

        //Read elements and list of elements
        public List<BankAccount> GetList()
        {
            BankAccountMultiuserEntities3 dbConnection = new BankAccountMultiuserEntities3();

            List<BankAccounts> bankAccountsListFromDB = dbConnection.BankAccounts.ToList();

            List<BankAccount> result = new List<BankAccount>();
            foreach (BankAccounts bankAccountFromDB in bankAccountsListFromDB)
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

        //Create new element
        public BankAccount CreateBankAccount(BankAccount newBankAccount)
        {
            BankAccount result = null;

            BankAccounts dataToSaveInDB = new BankAccounts
            {
                AccountId = newBankAccount.AccountNumber,
                AccountPin = newBankAccount.PinNumber.ToString(),
                Money = newBankAccount.Balance,
                Movements = new List<Movements>()
            };
            _dbConnection.BankAccounts.Add(dataToSaveInDB);
            _dbConnection.SaveChanges();

            foreach (var domainMovement in newBankAccount.Movements)
            {
                dataToSaveInDB.Movements.Add(new Movements
                {
                    Amount = domainMovement.Amount,
                    Datetime = domainMovement.Timestamp,
                    BankAccountId = dataToSaveInDB.Id
                });
            }
            _dbConnection.SaveChanges();
            result = newBankAccount;
            return result;
        }

        //Read List From DB
        public List<BankAccount> GetListFromDB()
        {
            List<BankAccount> result = null;
            List<BankAccounts> bankAccountsList = _dbConnection.BankAccounts.ToList();
            if (bankAccountsList != null)
            {
                result = new List<BankAccount>();
                foreach (BankAccounts bankAccount in bankAccountsList)
                {
                    result.Add(new BankAccount
                    {
                        AccountNumber = bankAccount.AccountId,
                        PinNumber = int.Parse(bankAccount.AccountPin),
                        Balance = bankAccount.Money,
                        Movements = new List<Movement>()
                    });
                    foreach (Movements accountMove in bankAccount.Movements)
                    {
                        result.Last().Movements.Add(new Movement
                        {
                            Amount = accountMove.Amount,
                            Timestamp = accountMove.Datetime
                        });
                    }
                }
            }
            return result;
        }


        public BankAccount GetById(string AccountId)
        {
            BankAccount result = null;

            BankAccounts workerIdFromDB = _dbConnection.BankAccounts.FirstOrDefault(x => x.AccountId == AccountId);
            if (workerIdFromDB != null)
            {
                result = new BankAccount
                {
                    AccountNumber = workerIdFromDB.AccountId,
                    PinNumber = int.Parse(workerIdFromDB.AccountPin),
                    Balance = workerIdFromDB.Money,
                    Movements = new List<Movement>()
                };
                foreach (Movements movesOfWorkerId in workerIdFromDB.Movements)
                {
                    result.Movements.Add(new Movement
                    {
                        Amount = movesOfWorkerId.Amount,
                        Timestamp = movesOfWorkerId.Datetime
                    });
                }
            }

            return result;
        }

        //Update existing element
        public BankAccount Update(BankAccount bankAccountDomain)
        {
            BankAccount result = null;

            //Devuelve un objeto si esta en base de datos mediante el identificador
            BankAccounts accountData = _dbConnection.BankAccounts.FirstOrDefault(e => e.AccountId == bankAccountDomain.AccountNumber);
            if (accountData != null)
            {
                accountData.AccountId = bankAccountDomain.AccountNumber;
                accountData.AccountPin = bankAccountDomain.PinNumber.ToString();
                accountData.Money = bankAccountDomain.Balance;

                foreach (Movement moveFromDomain in bankAccountDomain.Movements)
                {
                    if (!accountData.Movements.Any(x => x.Datetime == moveFromDomain.Timestamp))
                    {
                        accountData.Movements.Add(new Movements
                        {
                            Amount = moveFromDomain.Amount,
                            Datetime = moveFromDomain.Timestamp,
                            BankAccountId = accountData.Id,
                            BankAccounts = accountData
                        });
                    }
                }
                result = new BankAccount
                {
                    AccountNumber = accountData.AccountId,
                    PinNumber = bankAccountDomain.PinNumber,
                    Balance = bankAccountDomain.Balance,
                    Movements = new List<Movement>()
                };
                foreach (Movements relatedMove in accountData.Movements)
                {
                    result.Movements.Add(new Movement
                    {
                        Amount = relatedMove.Amount,
                        Timestamp = relatedMove.Datetime
                    });
                }
            }
            return result;
        }

        //Delete element

        public bool PhysicalRemoveFromDB(string accountID)
        {
            bool result = false;

            BankAccounts accountData = _dbConnection.BankAccounts.FirstOrDefault(e => e.AccountId == accountID);
            if (accountData != null)
            {
                if(accountData.Movements.Count() > 0)
                {
                    _dbConnection.Movements.RemoveRange(accountData.Movements);
                }
                _dbConnection.BankAccounts.Remove(accountData);
                _dbConnection.SaveChanges();
            }

                return result;
        }


        public void SetBankAccount(BankAccounts newDataForBankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
