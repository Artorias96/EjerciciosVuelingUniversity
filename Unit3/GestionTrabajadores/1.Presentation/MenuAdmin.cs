using GestionTrabajadores._2.Bussiness.Contracts;
using GestionTrabajadores._3.Domain.IRepositories;
using GestionTrabajadores._3.Domain.Repositories;
using GestionTrabajadores.Bussiness;
using GestionTrabajadores.Bussiness.Verifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class MenuAdmin
    {
        ValidationsInputs verificateString = new ValidationsInputs();

        private readonly IMenuAdminService _menuAdminService;

        public MenuAdmin(IMenuAdminService menuAdminService) 
        { 
            _menuAdminService = menuAdminService;   
        }


        ITWorker Worker;
        Task Task;
        Team Team;

        public void MenuAdminManagement()
        {
            bool exit = false;

            string separator = "-------------------------------------------------------------------------------------------------------------------";
            string messageMenu = "Select one of the options \n 1. Register new IT worker \n 2. Register new team \n 3. Register new task(unassigned to anyone)" +
                " \n 4. List all team names \n 5. List team members by team name \n 6. List unassigned tasks \n 7. List task assignments by team name \n 8. Assign ITworker to a team as manager \n 9. Assign IT worker to a team as technician" +
                "\n 10. Assign task to IT worker \n 11. Unregister worker \n 12. Exit";
            string optionNotValidError = "Error, you have to choose one of the options between 1-12";

            Console.WriteLine("Welcome to the worker management application.");

            Console.WriteLine(separator);

            do
            {
                Console.WriteLine(messageMenu);
                Console.WriteLine(separator);

                try
                {
                    var option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {

                        case 1:

                            var name = verificateString.ValidateString("Worker Name:");

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

                            if(_menuAdminService.AddNewWorker(name, surName, dt, yearsExperience, levelOfWorker, knowledge))
                            {
                                Console.WriteLine("Worker Add succesfully");
                            }
                            else
                            {
                                Console.WriteLine("something was wrong");
                            }


                            break;

                        case 2:

                            try
                            {
                                Console.Clear();

                                string nameOfTeam = verificateString.ValidateString("Introduce the name of the team you want to add");

                                if (_menuAdminService.AddNewTeam(nameOfTeam))
                                {
                                    Console.WriteLine($"Team Added succesfully");
                                }
                                else
                                {
                                    Console.WriteLine("Error something was wrong");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error, please introduce correct format");
                            }
                            break;

                        case 3:

                            Console.Clear();

                            int id = verificateString.ValidateInt("Introduce ID for the task");

                            string description = verificateString.ValidateString("Introduce description of the new task");

                            string technology = verificateString.ValidateString("Introduce the technology to use");

                            if (_menuAdminService.AddNewTask(id, description, technology))
                            {
                                Console.WriteLine("Task added sucessfully");
                            }
                            else
                            {
                                Console.WriteLine("Error something was wrong");
                            }

                            break;

                        case 4:

                            Console.Clear();
                            Console.WriteLine($"List of all Team names: ");

                            string strTeam = "";
                            foreach (var item in _menuAdminService.ListAllTeams())
                            {
                                strTeam += item.TeamName;
                                strTeam += "\n";
                            }
                            Console.WriteLine(strTeam);    

                            break;

                        case 5:
                            //LIST TEAM MEMBERS BY TEAM NAME

                            Console.Clear();

                            string selectTeamName = "";
                            foreach (var item in _menuAdminService.ListAllTeams())
                            {
                                selectTeamName += item.TeamName;
                                selectTeamName += "\n";
                            }
                            Console.WriteLine(selectTeamName);

                            string teamname = verificateString.ValidateString("Select the team by the name");

                            Console.WriteLine("Members of the team:");

                           
                            break;

                        case 6:
                            //LIST UNASSIGNED TASKS
                            Console.Clear();

                            Console.WriteLine("List of all unasigned task");

                            string strTask = "";
                            foreach (var item in _menuAdminService.ListAllTasks())
                            {
                                if (item.assigned == false)
                                {
                                    strTask += item.Description;
                                    strTask += "\n";
                                }
                            }
                            Console.WriteLine(strTask);

                            //details.ShowUnassignedTask(_TasksList);
                            break;

                        case 7:
                            //LIST TASK ASSIGNED BY TEAM NAME

                            //assignedAs.AssignedsTaskByTeam(_Teams, _TasksList);

                            break;

                        case 8:
                            //ASSIGN ITWORKER TO TEAM AS MANAGER
                            //assignedAs.AssignWorkerAsManager(_Teams, _ItWorkersList);

                            break;

                        case 9:
                            //ASSIGN ITWORKER AS TECH
                            //assignedAs.AssignWorkerAsTechnician(_Teams, _ItWorkersList);

                            break;

                        case 10:
                            //ASSIGN TASK TO ITWORKER

                            //assignedAs.AssignTaskToWorker(_TasksList, _ItWorkersList);


                            break;


                        case 11:
                            //UNREGISTER WORKER

                            //delete.DeleteWorker(_ItWorkersList);

                            break;


                        case 12:

                            exit = true;

                            break;

                        default:

                            Console.WriteLine(optionNotValidError);
                            exit = false;
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                Console.WriteLine(separator);

            } while (!exit);

            Console.ReadKey();
        }

        private void KnowledgesWorker(List<string> knowledges)
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
                }
                else if (answer == "n")
                {
                    exit = true;
                }
            } while (!exit);

        }

    }
}
