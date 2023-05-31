using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string messageMenu = "Welcome to the bank management application \n Select one of the options \n 1. Money Income \n 2. Money outcome \n 3. List All Movements \n 4. List incomes \n 5. List outcomes \n 6. Show current money \n 7. Exit";


            Account user1 = new Account();
            Money transaction1 = new Money();
            bool exit = false;


            do
            {

                bool correctSession = false;
                while (!correctSession)
                {

                    Console.WriteLine("To access the application you must start Session \n Number Account: ");
                    string accountNumber = Console.ReadLine();
                    Console.WriteLine("PIN number:");
                    int pinNumber;

                    try
                    {
                        pinNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }

                    if (user1.VerifyUser(accountNumber, pinNumber))
                        correctSession = true;
                    else
                        correctSession = false;


                }

                bool exitMenu = false;

                while (!exitMenu)
                {
                    Console.WriteLine(messageMenu);

                    string entrada = Console.ReadLine();

                    switch (entrada)
                    {
                        case "1":

                            MethodCase1(transaction1);
                            break;

                        case "2":

                            MethodCase2(transaction1);
                            break;

                        case "3":

                            Console.WriteLine($"Total movements made: {transaction1.getAllMovements()}");

                            Console.WriteLine();
                            break;

                        case "4":

                            Console.WriteLine($"Input movements made: {transaction1.getDeposits()}");
                            Console.WriteLine();
                            break;

                        case "5":

                            Console.WriteLine($"Withdrawal movements made: {transaction1.getWithdraws()}");
                            Console.WriteLine();
                            break;

                        case "6":

                            Console.WriteLine($"Your current balance is: {transaction1.getBalance()}");

                            Console.WriteLine();
                            break;

                        case "7":

                            exitMenu = true;
                            break;

                        default:
                            break;
                    }
                }
                exit = true;
            } while (!exit);


        }

        private static void MethodCase2(Money transaction1)
        {
            Console.WriteLine("Introduzca la cantidad que quiere retirar");
            decimal moneyWithdraw = Convert.ToDecimal(Console.ReadLine());
            if (transaction1.getBalance() < moneyWithdraw)
            {
                Console.WriteLine("Saldo Insuficiente");
            }
            else
            {
                transaction1.Withdraw(moneyWithdraw);
            }
            Console.WriteLine();
        }

        private static void MethodCase1(Money transaction1)
        {
            Console.WriteLine("Introduzca la cantidad que quiere depositar");

            decimal moneyDeposit = Convert.ToDecimal(Console.ReadLine());

            transaction1.Deposit(moneyDeposit);

            Console.WriteLine();
        }
    }
}
