using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Version1



            bool exit = false;
            decimal saldo = 0;
            List<decimal> AllMovements = new List<decimal>();
            List<decimal> MovementsIncome = new List<decimal>();
            List<decimal> MovementsOutcome = new List<decimal>();
            do
            {
                Console.WriteLine("Bienvenido a la aplicacion de gestion bancaria");
                Console.WriteLine("seleccione una de las opciones");
                Console.WriteLine("1. Money income");
                Console.WriteLine("2. Money outcome");
                Console.WriteLine("3. List all movements");
                Console.WriteLine("4. List incomes");
                Console.WriteLine("5. List outcomes");
                Console.WriteLine("6. Show current money");
                Console.WriteLine("7. Exit");
                string entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "1":

                        Console.WriteLine("Introduzca la cantidad que quiere depositar");
                        decimal dineroDepositado = Convert.ToDecimal(Console.ReadLine());
                        saldo += dineroDepositado;
                        AllMovements.Add(dineroDepositado);
                        MovementsIncome.Add(dineroDepositado);

                        Console.WriteLine("\n");
                        break;

                    case "2":

                        Console.WriteLine("Introduzca la cantidad que quiere retirar");
                        decimal dineroRetirado = Convert.ToDecimal(Console.ReadLine());
                        if (saldo < dineroRetirado)
                        {
                            Console.WriteLine("Saldo Insuficiente");
                        }
                        else
                        {
                            saldo -= dineroRetirado;
                            AllMovements.Add(dineroRetirado);
                            MovementsOutcome.Add(dineroRetirado);
                        }

                        Console.WriteLine("\n");
                        break;

                    case "3":

                        Console.WriteLine("Movimientos realizados totales: ");
                        foreach (var item in AllMovements)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("\n");
                        break;

                    case "4":

                        Console.WriteLine("Movimientos de entrada realizados: ");
                        foreach (var item in MovementsIncome)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n");
                        break;

                    case "5":

                        Console.WriteLine("Movimientos de retirada realizados: ");
                        foreach (var item in MovementsOutcome)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n");
                        break;

                    case "6":
                        Console.WriteLine($"Su saldo actual es de: {saldo}");

                        Console.WriteLine("\n");
                        break;

                    case "7":

                        exit = true;
                        break;

                    default:
                        break;

                }


            } while (!exit);

            #endregion

            #region Version2

            Dictionary<string, int> InicioSesion = new Dictionary<string, int>();

            InicioSesion.Add("ES54962", 1697);
            InicioSesion.Add("ES65484", 2428);
            InicioSesion.Add("ES32154", 6827);

            bool exit1 = false;
            int saldo1 = 0;
            List<int> AllMovements1 = new List<int>();
            List<int> MovementsIncome1 = new List<int>();
            List<int> MovementsOutcome1 = new List<int>();
            do
            {
                bool inicioCorrecto = false;


                while (!inicioCorrecto)
                {
                    Console.WriteLine("Para Acceder a la aplicacion antes debe iniciar Sesion");
                    Console.WriteLine("Numero de Cuenta:");
                    string entradaCuenta = Console.ReadLine();
                    Console.WriteLine("Numero PIN:");
                    string entradaPin = Console.ReadLine();

                    if (InicioSesion.ContainsKey(entradaCuenta) && InicioSesion.ContainsKey(entradaPin))
                    {
                        inicioCorrecto = true;
                    }
                    else
                    {
                        Console.WriteLine("¿Cuenta erronea, desea volver a intentarlo? s/n");
                        string en = Console.ReadLine();
                        if (en.ToLower().Equals("s"))
                        {

                        }
                        else if (en.ToLower().Equals("n"))
                        {
                            exit1 = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Formato incorrecto, vuleva a introducir los datos");
                        }
                    }
                }

                Console.WriteLine("-----------------------------------------------------------------------");


                Console.WriteLine("Bienvenido a la aplicacion de gestion bancaria");
                Console.WriteLine("seleccione una de las opciones");
                Console.WriteLine("1. Money income");
                Console.WriteLine("2. Money outcome");
                Console.WriteLine("3. List all movements");
                Console.WriteLine("4. List incomes");
                Console.WriteLine("5. List outcomes");
                Console.WriteLine("6. Show current money");
                Console.WriteLine("7. Exit");
                string entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "1":

                        Console.WriteLine("Introduzca la cantidad que quiere depositar");
                        int dineroDepositado = Convert.ToInt32(Console.ReadLine());
                        saldo1 += dineroDepositado;
                        AllMovements1.Add(dineroDepositado);
                        MovementsIncome1.Add(dineroDepositado);

                        Console.WriteLine("\n");
                        break;

                    case "2":

                        Console.WriteLine("Introduzca la cantidad que quiere retirar");
                        int dineroRetirado = Convert.ToInt32(Console.ReadLine());
                        if (saldo1 < dineroRetirado)
                        {
                            Console.WriteLine("Saldo Insuficiente");
                        }
                        else
                        {
                            saldo1 -= dineroRetirado;
                            AllMovements.Add(dineroRetirado);
                            MovementsOutcome.Add(dineroRetirado);
                        }

                        Console.WriteLine("\n");
                        break;

                    case "3":

                        Console.WriteLine("Movimientos realizados totales: ");
                        foreach (var item in AllMovements1)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("\n");
                        break;

                    case "4":

                        Console.WriteLine("Movimientos de entrada realizados: ");
                        foreach (var item in MovementsIncome1)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n");
                        break;

                    case "5":

                        Console.WriteLine("Movimientos de retirada realizados: ");
                        foreach (var item in MovementsOutcome1)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n");
                        break;

                    case "6":
                        Console.WriteLine($"Su saldo actual es de: {saldo}");

                        Console.WriteLine("\n");
                        break;

                    case "7":

                        exit1 = true;
                        break;

                    default:
                        break;

                }


            } while (!exit);

            #endregion
        }
    }
}