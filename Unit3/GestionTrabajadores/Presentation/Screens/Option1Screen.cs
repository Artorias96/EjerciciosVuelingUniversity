using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation
{
    public class Option1Screen
    {

        public void Start(List<ITWorker> ItWorkersList, ITWorker worker)
        {

            try
            {
                Console.Clear();
                bool exit = false;
                do
                {
                    
                    Console.WriteLine("Worker name:");
                    var name = Console.ReadLine();

                    if(Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("FALSE");
                    }

                    //Surname
                    Console.WriteLine("Worker surname: ");
                    var surName = Console.ReadLine();

                    //Birthday
                    Console.WriteLine("Introduce Birthday in format dd/mm/aaaa:");
                    string birthday = Console.ReadLine();

                    DateTime dt;


                    if (DateTime.TryParseExact(birthday, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                    {
                        // Calculamos la edad
                        int age = DateTime.Today.Year - dt.Year;
                        if (DateTime.Today < dt.AddYears(age))
                            age--;

                        // Verificamos si es mayor de edad o no
                        if (age <= 18)
                        {
                            Console.WriteLine("You can´t add a worker under the legal age");
                            break;
                        }
                        else
                            Console.WriteLine("Age Validated");
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("The datetime format introduced is not valid.");
                        break;
                    }

                    Console.WriteLine("Years of experience");
                    var yearsExperience = Convert.ToInt32(Console.ReadLine());

                    //Enum
                    Console.WriteLine("Introduce level \n 1-Junior \n 2-Medium \n 3-Senior");
                    var level = Convert.ToInt32(Console.ReadLine());


                    //knowledges
                    var knowledge = new List<string>();
                    Console.WriteLine("Write your knowledges one by one");
                    KnowledgesWorker(knowledge);

                    worker = new ITWorker(name, surName, dt, yearsExperience, (LevelWorker)level, knowledge);
                    ItWorkersList.Add(worker);

                    worker.ShowValues();


                } while (!exit);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void KnowledgesWorker(List<string> knowledge)
        {
            bool more = true;
            do
            {
                Console.WriteLine("Write one Knowledge:");
                knowledge.Add(Console.ReadLine());

                Console.WriteLine("¿Add more knowledges? y/n");
                var answer = Console.ReadLine();
                if (answer == "n")
                {
                    more = false;
                }
                else if (answer == "y")
                {
                    more = true;
                }
                else if (answer != "y" || answer != "n")
                {
                    Console.WriteLine("Please introduce 'y' or 'n'");
                    break;
                }

            } while (more);
        }


    }
}
