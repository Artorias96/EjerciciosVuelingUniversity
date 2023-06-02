using GestionTrabajadores.Presentation;
using GestionTrabajadores.Presentation.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class MenuManagement
    {
        public List<ITWorker> ItWorkersList = new List<ITWorker>();
        public List<Task> TasksList = new List<Task>();
        public List<Team> Teams = new List<Team>();

        Option1Screen Option1Screen = new Option1Screen();
        Option2Screen Option2Screen = new Option2Screen();
        Option3Screen Option3Screen = new Option3Screen();
        Option4Screen Option4Screen = new Option4Screen();
        Option5Screen Option5Screen = new Option5Screen();
        Option6Screen Option6Screen = new Option6Screen();
        Option7Screen Option7Screen = new Option7Screen();
        Option8Screen Option8Screen = new Option8Screen();
        Option9Screen Option9Screen = new Option9Screen();

        ITWorker Worker;
        ITWorker myWorker1 = new ITWorker("Paco","Jones",new DateTime(1990, 7, 12),5,LevelWorker.Senior,new List<string> { "C#", "ASP.NET", "SQL" });
        ITWorker myWorker2 = new ITWorker("Elber", "Gadura", new DateTime(1998, 4, 9), 2, LevelWorker.Junior, new List<string> { "Python", "Java", "HTML" });
        ITWorker myWorker3 = new ITWorker("Rosa", "Melano", new DateTime(2000, 4, 26), 3, LevelWorker.Medium, new List<string> { "C++", "JavaScript", "php" });

        Task Task;
        Task task1 = new Task("Task number 1", "C#", Status.ToDo);
        Task task2 = new Task("Task number 2", "Python", Status.Doing);
        Task task3 = new Task("Task number 3", "php", Status.Done);

        Team Team;
        Team team1 = new Team("Team Paco");
        Team team2 = new Team("Team Elber");
        Team team3 = new Team("Team Rosa");

        
        public void Start()
        {
            Team team;
            ITWorker worker;
            Task task;

            ItWorkersList.Add(myWorker1);
            ItWorkersList.Add(myWorker2);
            ItWorkersList.Add(myWorker3);

            TasksList.Add(task1);
            TasksList.Add(task2);
            TasksList.Add(task3);

            Teams.Add(team1);
            Teams.Add(team2);
            Teams.Add(team3);

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

                            Option1Screen.Start(ItWorkersList, Worker);
                           
                            break;

                        case 2:

                            Option2Screen.Start(Teams, Team);

                            break;

                        case 3:

                            Option3Screen.Start(Task, TasksList);


                            break;

                        case 4:

                            Option4Screen.Start(Teams);


                            break;

                        case 5:

                            Option5Screen.Start(Teams, ItWorkersList);

                            break;

                        case 6:

                            Option6Screen.Start(TasksList);
                            break;

                        case 7:

                            Option7Screen.Start(Teams, TasksList);

                            break;

                        case 8:

                            Option8Screen.Start(Teams, ItWorkersList);

                            break;

                        case 9:

                            Option9Screen.Start(Teams, ItWorkersList);

                            break;

                        case 10:


                            Console.Clear();
                            Console.WriteLine("What task you want to assign?: (Select the number of task)");

                            foreach (var item in TasksList.Where(e => e.assigned == false))
                            {
                                Console.WriteLine($"Task:{item.IdTask} \n" +
                                    $"Task description: {item.Description}\n");
                            }

                            var answerTask = Convert.ToInt32(Console.ReadLine());

                            if (answerTask == 0)
                            {
                                Console.WriteLine("You need to choose the number of the task");

                            }

                            Task taskValue = TasksList.FirstOrDefault(e => e.IdTask == answerTask);



                            Console.WriteLine("Select the ID of the worker: ");

                            foreach (var item in ItWorkersList)
                            {
                                Console.WriteLine($"ID Worker:{item.ItWorkerId} \n" +
                                    $"Worker name: {item.Name}\n");
                            }

                            var answerWor = Convert.ToInt32(Console.ReadLine());

                            if (answerWor == 0)
                            {
                                Console.WriteLine("Error, Choose Id number of worker");
                            }

                            ITWorker workerVal = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWor);

                            taskValue.Worker = workerVal;

                            workerVal.TaskWorker = taskValue;

                            taskValue.assigned = true;


                            if (taskValue.StatusTask != Status.Done || workerVal.TechKnowledges.FirstOrDefault().Equals(taskValue.Technology))
                            {
                                

                                Console.WriteLine($"---------- Task Description Selected ----------");

                                taskValue.ShowValues();

                                Console.WriteLine("---------- Worker Description of task assigned ----------");

                                workerVal.ShowValues();

                            }
                            else Console.WriteLine("The worker need to Know the tech of the task, and the task cant be in State Done");


                            break;


                        case 11:


                            Console.Clear();
                            Console.WriteLine("Select by ID the worker to unregistered");

                            foreach (var item in ItWorkersList)
                            {
                                Console.WriteLine($"Worker ID: {item.ItWorkerId}");
                            }

                            var workerToRemove = Convert.ToInt32(Console.ReadLine());

                            if (workerToRemove == 0)
                            {
                                Console.WriteLine("Please select a worker ID");
                            }

                            var workerRemoved = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == workerToRemove);

                            ItWorkersList.Remove(workerRemoved);
                            workerRemoved.TeamWorker = null;
                            workerRemoved.TaskWorker = null;

                            var today = DateTime.Today;

                            workerRemoved.LeavingDate = today;

                            Console.WriteLine($"day of worker unregistered : {workerRemoved.LeavingDate}");

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

        public ITWorker GetWorkerById(int id)
        {
            var worker = ItWorkersList.Where(ITWorker => ITWorker.ItWorkerId == id).FirstOrDefault();

            return worker;
        }

        public Team GetTeamByTeamName(string name)
        {
            var team = Teams.Where(Team => Team.TeamName == name).FirstOrDefault();

            return team;
        }
    }
}
