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

                    Console.WriteLine("Worker name:");
                    var name = Console.ReadLine();

                    if (verificateString.ValidateStringInput(name) == "")
                    {
                        break;
                    }

                    //Surname
                    Console.WriteLine("Worker surname: ");
                    var surName = Console.ReadLine();

                    if (verificateString.ValidateStringInput(surName) == "")
                    {
                        break;
                    }

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


                    worker = new ITWorker(name, surName, dt, yearsExperience, levelOfWorker, knowledge);
                    ItWorkersList.Add(worker);

                    worker.ShowValues();


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
            team = new Team(nameOfTeam);
            Teams.Add(team);

            Console.WriteLine($"Team With Name: {team.TeamName} Added succesfully");

        }

        public void RegisterNewTask(Task task, List<Task> TasksList)
        {
            Console.Clear();
            Console.WriteLine("Introduce description of the new task");
            string description = Console.ReadLine();

            Console.WriteLine("Introduce the technology to use");
            string technology = Console.ReadLine();

            Console.WriteLine("Introduce state of task \n 1-ToDo \n 2-Doing \n 3-Done");
            var status = Convert.ToInt32(Console.ReadLine());

            task = new Task(description, technology, (Status)status);

            TasksList.Add(task);

            Console.WriteLine($"Task With Id: {task.IdTask} Added succesfully");
        }

       
    }
}
