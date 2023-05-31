using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioParaCasa
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region PrimeraParte

            bool mayorDeEdad;
            int numeroEntero;
            decimal numeroDecimal;
            decimal resultado;
            char caracter;
            string texto;


            Console.WriteLine("Por favor, introduzca los siguientes datos");

            try
            {

                Console.WriteLine("Eres mayor de edad? (true/false)");
                mayorDeEdad = bool.Parse(Console.ReadLine());

                Console.WriteLine("Introduzca un numero");
                numeroEntero = int.Parse(Console.ReadLine());

                Console.WriteLine("Introduzca un numero decimal");
                numeroDecimal = decimal.Parse(Console.ReadLine());

                resultado = numeroEntero / numeroDecimal;

                Console.WriteLine("Introduzca una Letra");
                caracter = char.Parse(Console.ReadLine());

                Console.WriteLine("¿Cual es tu nombre?");
                texto = Console.ReadLine();

                Console.WriteLine("Introduzca una fecha con hora incluida DD/MM/YYYY HH/MM/SS ");
                DateTime fecha = DateTime.Parse(Console.ReadLine());
                fecha = fecha.AddSeconds(-1);



                Console.WriteLine("Mayor de edad:" + !mayorDeEdad);
                Console.WriteLine("Resultado de los numeros introducidos al dividirlos " + resultado);
                Console.WriteLine(caracter + "(" + texto + ")" + caracter);
                Console.WriteLine("Ultimo segundo del mes de la fecha introducida: " + fecha.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception)
            {
                Console.WriteLine("Los datos no son correctos, revise el formato pro favor.");
            }

            #endregion

            Console.WriteLine("---------------------------------------------------------------------------------");

            int[] Array = { 50, 76, 42, 61, 27 };

            List<string> lista = new List<string>();
            lista.Add("Paco");
            lista.Add("Roberto");
            lista.Add("Luis");

            Dictionary<string, int> diccionario = new Dictionary<string, int>();
            diccionario.Add("Chocolate", 1);
            diccionario.Add("Gominola", 2);
            diccionario.Add("Regaliz", 3);

            Console.WriteLine("Mostramos los elementos del array");

            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + Array[i]);
            }

            Console.WriteLine("Mostramos los elementos de la lista");

            foreach (string str in lista)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Mostramos los elementos del diccionario");

            foreach (var va in diccionario)
            {
                Console.WriteLine(va);
            }

            Console.WriteLine("---------------------------------------------------------------------------------");




        }
    }

}