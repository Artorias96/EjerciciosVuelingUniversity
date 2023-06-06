using GestionTrabajadores.Bussiness.Verifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionTrabajadores.Bussiness
{
    public class Registers
    {
        ValidationsInputs verificateString = new ValidationsInputs();
        public void RegisterNewWorker(List<ITWorker> ItWorkersList, ITWorker worker)
        {
            try
            {
                Console.Clear();
                bool exit = false;
                do
                {
   
                    var name  = verificateString.ValidateString("Worker Name:");

                    if (verificateString.ValidateStringContent(name) == "")
                    {
                        break;
                    }

                    //Surname
                    var surName = verificateString.ValidateString("Worker surname: ");

                    if (verificateString.ValidateStringContent(surName) == "")
                    {
                        break;
                    }

                    //Birthday;

                    var birthday = verificateString.ValidateString("Introduce Birthday in format dd/mm/aaaa: ");

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

                    var yearsExperience = verificateString.ValidateInt("Years of experience");

                    //Enum

                    var level = verificateString.ValidateInt("Introduce level \n 1-Junior \n 2-Medium \n 3-Senior");

                    var levelOfWorker = LevelWorker.Junior;

                    switch (level)
                    {
                        case 1:

                            break;

                        case 2:
                            levelOfWorker = LevelWorker.Medium;
                            break;

                        case 3:
                            if (yearsExperience >= 5)
                            {
                                levelOfWorker = LevelWorker.Senior;
                            }
                            else
                            {
                                Console.WriteLine("The worker only can be Senior with 5 years of experience or more.");
                                continue;
                            }

                            break;
                    }

                    List<string> knowledge = new List<string>();

                    KnowledgesWorker(knowledge);


                    //worker = new ITWorker(name, surName, dt, yearsExperience, levelOfWorker, knowledge);
                    //ItWorkersList.Add(worker);

                    //worker.ShowValues();


                } while (!exit);
            }
            catch (Exception e)

            {
                Console.WriteLine(e.Message);
            }
        }

        public void RegisterNewTeam(List<Team> Teams, Team team) 
        {
            Console.Clear();
            Console.WriteLine("Introduce the name of the team you want to add");
            string nameOfTeam = Console.ReadLine();
            //team = new Team(nameOfTeam);
            Teams.Add(team);

            Console.WriteLine($"Team With Name: {team.TeamName} Added succesfully");

        }

        public void RegisterNewTask(Task task, List<Task> TasksList)
        {
            Console.Clear();
            Console.WriteLine("Introduce ID for the task");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduce description of the new task");
            string description = Console.ReadLine();

            Console.WriteLine("Introduce the technology to use");
            string technology = Console.ReadLine();

            TasksList.Add(task);

            Console.WriteLine($"Task With Id: {task.IdTask} Added succesfully");
        }

        public void KnowledgesWorker(List<string> knowledges)
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Introduce knowledges one by one");
                string knowledge = Console.ReadLine();
                knowledges.Add(knowledge);

                Console.WriteLine("Add more knowledges? y/n");
                var answer = Console.ReadLine();
                if (answer == "y")
                {
                    continue;
                }else if(answer == "n")
                {
                    exit = true;
                }
            }while(!exit);

        }


    }
}
