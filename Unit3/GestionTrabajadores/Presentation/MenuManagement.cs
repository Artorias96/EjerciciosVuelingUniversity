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
        Option10Screen Option10Screen = new Option10Screen();
        Option11Screen Option11Screen = new Option11Screen();

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


                            Option10Screen.Start(TasksList, ItWorkersList);


                            break;


                        case 11:

                            Option11Screen.Start(ItWorkersList);
                            
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

    }
}
