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
        private List<ITWorker> _ItWorkersList = new List<ITWorker>();
        private List<Task> _TasksList = new List<Task>();
        private List<Team> _Teams = new List<Team>();

        public void Start()
        {


            Builder builderObjects = new Builder();

            Team team;
            ITWorker worker;
            Task task;

            bool exit = false;

            string messageMenu = "Select one of the options \n 1. Register new IT worker \n 2. Register new team \n 3.Register new task(unassigned to anyone)" +
                " \n 4. List all team names \n 5. List team members by team name \n 6. List unassigned tasks \n 7. List task assignments by team name \n 8. Assign ITworker to a team as manager \n 9. Assign IT worker to a team as technician" +
                "\n 10. Assign task to IT worker \n 11. Unregister worker \n 12. Exit";
            string optionNotValidError = "Error, you have to choose one of the options between 1-12";

            Console.WriteLine("Welcome to the worker management application.");

            do
            {

                Console.WriteLine(messageMenu);

                try
                {
                    var option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {

                        case 1:

                            Console.WriteLine("Worker name:");
                            var name = Console.ReadLine();

                            //Surname
                            Console.WriteLine("Worker surname: ");
                            var surName = Console.ReadLine();

                            //Validate Age of Itworker

                            DateTime dt;

                            //Birthday
                            Console.WriteLine("Birthday of the worker (dd/MM/yyyy) : ");
                            string birthday = Console.ReadLine();

                            dt = ValidateBirthday(ref birthday);
                            // Save today's date.
                            //var today = DateTime.Today;
                            //// Calculate the age.
                            //int age = today.Year - dt.Year;

                            //if (age < 18)
                            //{
                            //    Console.WriteLine("You can´t add a Worker under the legal age");
                            //}
                            //Years experience
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

                            _ItWorkersList.Add(worker);


                            break;

                        case 2:
                            Console.WriteLine("Introduce the name of the team you want to add");
                            string nameOfTeam = Console.ReadLine();

                            team = new Team(nameOfTeam);

                            _Teams.Add(team);

                            break;

                        case 3:

                            Console.WriteLine("Introduce description of the new task");
                            string description = Console.ReadLine();

                            Console.WriteLine("Introduce the technology to use");
                            string technology = Console.ReadLine();

                            Console.WriteLine("Introduce state of task \n 1-ToDo \n 2-Doing \n 3-Done");
                            var status = Convert.ToInt32(Console.ReadLine());

                            task = new Task(description, technology, (Status)status);

                            _TasksList.Add(task);


                            break;

                        case 4:

                            Console.WriteLine($"List of all Team names: ");

                            foreach (var item in _Teams)
                            {
                                Console.WriteLine($"Nombre del equipo: {item.TeamName}\n");
                            }

                            _Teams.ForEach(Console.WriteLine);

                            break;

                        case 5:
                            //Console.WriteLine("Choose the team Name: ");
                            Console.WriteLine("Select the Name of the Team: ");

                            foreach (var item in _Teams)
                            {
                                Console.WriteLine($"Name Team: {item.TeamName}");

                            }

                            var answerTeam = (Console.ReadLine());

                            if (answerTeam == null)
                            {
                                Console.WriteLine("Please entry a real name");
                            }

                            Team teamname = _Teams.FirstOrDefault(e => e.TeamName == answerTeam);

                            teamname.TeamName = answerTeam;

                            Console.WriteLine("Select the Worker by Id");

                            foreach(var item in _ItWorkersList)
                            {
                                Console.WriteLine($"Worker Id: {item.ItWorkerId}");
                            }

                            var answerWorkerId = Convert.ToInt32(Console.ReadLine());

                            ITWorker workerid = _ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWorkerId);

                            workerid.ItWorkerId = answerWorkerId;

                            teamname.workersInTeam.Add(workerid);

                            workerid.TeamWorker = teamname;

                            break;

                        case 6:

                           Console.WriteLine("Unassigned Tasks: ");

                           foreach(var item in _TasksList.Where(e => e.assigned == false))
                            {
                                Console.WriteLine($"Description: {item.Description} \n" +
                                    $"Tech: {item.Technology}\n" +
                                    $"Task Id: {item.IdTask}");
                            }
                            break;

                        case 7:
                            Console.WriteLine("List of the task Assigneds: (select Id number)");

                            foreach (var item in _TasksList.Where(e => e.assigned == true))
                            {
                                Console.WriteLine($"Id Tasks assigneds: {item.IdTask}" +
                                    $"Task Descripton: {item.Description}");
                            }

                            var answerTaskAssigned = Convert.ToInt32(Console.ReadLine());

                            if (answerTaskAssigned == 0)
                            {
                                Console.WriteLine("Error, the number dosen´t exists");
                            }

                            Task taskassigned = _TasksList.FirstOrDefault(e => e.IdTask == answerTaskAssigned);

                            Console.WriteLine("List of teams by the team name: ");

                            foreach (var item in _Teams)
                            {
                                Console.WriteLine($"Team: {item.TeamName}");
                            }

                            var answerTeamTask = Console.ReadLine();

                            if (answerTeamTask == null)
                            {
                                Console.WriteLine("Please entry a real name");
                            }

                            Team teamTaskAssigned = _Teams.FirstOrDefault(e => e.TeamName == answerTeamTask);

                            teamTaskAssigned.taskInTeam.Add(taskassigned);

                            taskassigned.TeamTask= teamTaskAssigned;

                            break;

                        case 8:

                            Console.WriteLine("Choose the name of the team to add a manager: ");

                            foreach (var item in _Teams)
                            {
                                Console.WriteLine($"Team: {item.TeamName}");
                            }
                            var answerteam = Console.ReadLine();

                            if(answerteam == null)
                            {
                                Console.WriteLine("Please entry a real name");
                            }

                            Team teammanager = _Teams.FirstOrDefault(e => e.TeamName == answerteam);

                            Console.WriteLine("Select the Number of the worker to add as manager");

                            foreach (var item in _ItWorkersList)
                            {
                                Console.WriteLine($"Worker Id: {item.ItWorkerId}");
                            }

                            var answerworker = Convert.ToInt32(Console.ReadLine());

                            if (answerworker == 0)
                            {
                                Console.WriteLine("Error, choose the number of the worker");
                            }

                            ITWorker workermanager = _ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerworker);

                            workermanager.TeamWorker = teammanager;

                            teammanager.Manager = workermanager;

                            break;

                        case 9:

                            Console.WriteLine("Select team by name");

                            foreach (var item in _Teams)
                            {
                                Console.WriteLine($"Team: {item.TeamName}");
                            }

                            var answertech = Console.ReadLine();

                            if (answertech == null)
                            {
                                Console.WriteLine("Error, the name dosen´t exit");
                            }

                            Team teamTech = _Teams.FirstOrDefault(e => e.TeamName == answertech);


                            //To Do
                            Console.WriteLine("Select the worker to add as technician by number of ID");

                            foreach(var item in _ItWorkersList)
                            {
                                Console.WriteLine($"IdWorker: {item.ItWorkerId}");
                            }

                            var answerWorkerTech = Convert.ToInt32(Console.ReadLine());

                            if (answerWorkerTech == 0)
                            {
                                Console.WriteLine("Please select a ID number that exists");
                            }

                            ITWorker workerTech = _ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWorkerTech);

                            workerTech.TeamWorker = teamTech;

                            teamTech.Technicians.Add(workerTech);

                            break;

                        case 10:

                            Console.WriteLine("What task you want to assign?: (Select the number of task)");

                            foreach (var item in _TasksList.Where(e => e.assigned == false))
                            {
                                Console.WriteLine($"Task:{item.IdTask} \n" +
                                    $"Task description: {item.Description}\n");
                            }

                            var answerTask = Convert.ToInt32(Console.ReadLine());

                            if(answerTask == 0)
                            {
                                Console.WriteLine("You need to choose the number of the task");

                            }
                            
                            Task taskValue = _TasksList.FirstOrDefault(e => e.IdTask == answerTask);

                            Console.WriteLine("Select the ID of the worker: ");

                            foreach (var item in _ItWorkersList)
                            {
                                Console.WriteLine($"ID Worker:{item.ItWorkerId} \n" +
                                    $"Worker name: {item.Name}\n");
                            }

                            var answerWor = Convert.ToInt32(Console.ReadLine());

                            if(answerWor == 0)
                            {
                                Console.WriteLine("Error, Choose Id number of worker");
                            }

                            ITWorker workerVal = _ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWor);

                            taskValue.Worker = workerVal;

                            workerVal.TaskWorker = taskValue;

                            taskValue.assigned = true;

                            Console.WriteLine($"Task: {taskValue}" + $"Assigned To Worker {workerVal}");

                            Console.WriteLine(workerVal.TaskWorker);
                            break;


                        case 11:

                            Console.WriteLine("Select by ID the worker to unregistered");

                            foreach (var item in _ItWorkersList)
                            {
                                Console.WriteLine($"Worker ID: {item.ItWorkerId}");
                            }

                            var workerToRemove = Convert.ToInt32(Console.ReadLine());

                            if (workerToRemove == 0)
                            {
                                Console.WriteLine("Please select a worker ID");
                            }

                            var workerRemoved = _ItWorkersList.FirstOrDefault(e => e.ItWorkerId == workerToRemove);

                            _ItWorkersList.Remove(workerRemoved);

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




            } while (!exit);

            Console.ReadKey();
        }

        private static void KnowledgesWorker(List<string> knowledge)
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

                    } else if (answer != "y" || answer != "n")
                    {
                        Console.WriteLine("Please introduce 'y' or 'n'");
                    break;
                    }
                
            } while (more);
        }

        private static DateTime ValidateBirthday(ref string birthday)
        {
            DateTime dt;
            while (!DateTime.TryParseExact(birthday, "dd/MM/yyyy",
                null, System.Globalization.DateTimeStyles.None,
                out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                birthday = Console.ReadLine();
            }

            return dt;
        }

        public ITWorker GetWorkerById(int id)
        {
            var worker = _ItWorkersList.Where(ITWorker => ITWorker.ItWorkerId == id).FirstOrDefault();
            
            return worker;
        }

        public Team GetTeamByTeamName(string name)
        {
            var team = _Teams.Where(Team => Team.TeamName == name).FirstOrDefault();

            return team;
        }
    }
}
