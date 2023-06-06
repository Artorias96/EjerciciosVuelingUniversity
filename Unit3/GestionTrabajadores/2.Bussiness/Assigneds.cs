//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GestionTrabajadores.Bussiness
////{
////    public class Assigneds
////    {

////        public void AssignWorkerByTeam(List<Team> Teams, List<ITWorker> ItWorkersList)
////        {
////            Console.Clear();
////            bool exit = false;
////            do
////            {

////                Console.WriteLine("Write the Name of the Team: ");

////                foreach (var item in Teams)
////                {
////                    Console.WriteLine($"Name Team: {item.TeamName}");

////                }

////                var answerTeam = (Console.ReadLine());

////                if (answerTeam == null)
////                {
////                    Console.WriteLine("Please entry a real name");
////                    break;
////                }

////                Team teamname = Teams.FirstOrDefault(e => e.TeamName == answerTeam);

////                teamname.TeamName = answerTeam;

////                Console.WriteLine("Select the Worker by Id");

////                foreach (var item in ItWorkersList)
////                {
////                    Console.WriteLine($"Worker Id: {item.ItWorkerId}");
////                }

////                var answerWorkerId = Convert.ToInt32(Console.ReadLine());

////                if (answerWorkerId == 0)
////                {
////                    Console.WriteLine("Error, choose the number of the worker");
////                    break;
////                }

////                ITWorker workerid = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWorkerId);

////                workerid.ItWorkerId = answerWorkerId;

////                workerid.TeamWorker = teamname;

////                teamname.workersInTeam.Add(workerid);

////                Console.WriteLine($"Team: {teamname.TeamName}");

////                Console.WriteLine("----------Worker Selected Description----------");

////                workerid.ShowValues();

////                exit = true;

////            } while (!exit);
////        }

////        public void AssignedsTaskByTeam(List<Team> Teams, List<Task> TasksList)
////        {
////            Console.Clear();

////            bool exit = false;
////            do
////            {
////                Console.WriteLine("List of the task Assigneds: (select Id number)");

////                foreach (var item in TasksList.Where(e => e.assigned == true))
////                {
////                    Console.WriteLine($"Id Tasks assigneds: {item.IdTask} \n" +
////                        $"Task Descripton: {item.Description}");
////                }

////                var answerTaskAssigned = Convert.ToInt32(Console.ReadLine());

////                if (answerTaskAssigned == 0)
////                {
////                    Console.WriteLine("Error, the number dosen´t exists");
////                    break;
////                }

////                Task taskassigned = TasksList.FirstOrDefault(e => e.IdTask == answerTaskAssigned);

////                Console.WriteLine("Select the team by the team name: ");

////                foreach (var item in Teams)
////                {
////                    Console.WriteLine($"Team: {item.TeamName}");
////                }

////                var answerTeamTask = Console.ReadLine();

////                if (answerTeamTask == null)
////                {
////                    Console.WriteLine("Please entry a real name");
////                    break;
////                }

////                Team teamTaskAssigned = Teams.FirstOrDefault(e => e.TeamName == answerTeamTask);

////                teamTaskAssigned.taskInTeam.Add(taskassigned);

////                taskassigned.TeamTask = teamTaskAssigned;


////                Console.WriteLine($"Team: {teamTaskAssigned.TeamName}");

////                Console.WriteLine($"----------Task Description Selected for {teamTaskAssigned.TeamName} ----------");

////                taskassigned.ShowValues();

////                exit = true;

////            } while (!exit);
////        }

////        public void AssignWorkerAsManager(List<Team> Teams, List<ITWorker> ItWorkersList)
////        {
////            Console.Clear();

////            bool exit = false;
////            do
////            {
////                Console.WriteLine("Choose the name of the team to add a manager: ");

////                foreach (var item in Teams)
////                {
////                    Console.WriteLine($"Team: {item.TeamName}");
////                }
////                var answerteam = Console.ReadLine();

////                if (answerteam == null)
////                {
////                    Console.WriteLine("Please entry a real name");
////                    break;
////                }

////                Team teammanager = Teams.FirstOrDefault(e => e.TeamName == answerteam);

////                Console.WriteLine("Select the Number of the worker to add as manager");

////                foreach (var item in ItWorkersList)
////                {
////                    Console.WriteLine($"Worker Id: {item.ItWorkerId}");
////                }

////                var answerworker = Convert.ToInt32(Console.ReadLine());

////                if (answerworker == 0)
////                {
////                    Console.WriteLine("Error, choose the number of the worker");
////                    break;
////                }

////                ITWorker workermanager = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerworker);

////                if (workermanager.LevelItWorker != LevelWorker.Senior)
////                {
////                    Console.WriteLine("The Level of the Worker need to be Senior ");
////                    break;
////                }

////                workermanager.TeamNameWorker = teammanager.TeamName;

////                teammanager.WorkerIdManager = workermanager.ItWorkerId;

////                Console.WriteLine($"Team: {teammanager.TeamName}");

////                Console.WriteLine("----------Worker Added As Manager Description----------");

////                workermanager.ShowValues();

////                exit = true;

////            } while (!exit);
////        }

////        public void AssignWorkerAsTechnician(List<Team> Teams, List<ITWorker> ItWorkersList)
////        {
////            Console.Clear();

////            bool exit = false;
////            do
////            {
////                Console.WriteLine("Select team by team name");

////                foreach (var item in Teams)
////                {
////                    Console.WriteLine($"Team: {item.TeamName}");
////                }

////                var answertech = Console.ReadLine();

////                if (answertech == null)
////                {
////                    Console.WriteLine("Error, the name dosen´t exit");
////                }

////                Team teamTech = Teams.FirstOrDefault(e => e.TeamName == answertech);


////                Console.WriteLine("Select the worker to add as technician by number of ID");

////                foreach (var item in ItWorkersList)
////                {
////                    Console.WriteLine($"IdWorker: {item.ItWorkerId}");
////                }

////                var answerWorkerTech = Convert.ToInt32(Console.ReadLine());

////                if (answerWorkerTech == 0)
////                {
////                    Console.WriteLine("Please select a ID number that exists");
////                }

////                ITWorker workerTech = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWorkerTech);

////                workerTech.TeamWorker = teamTech;

////                teamTech.Technicians.Add(workerTech);

////                Console.WriteLine($"Team: {teamTech.TeamName}");

////                Console.WriteLine("----------Worker Added As Technician Description----------");

////                workerTech.ShowValues();

////                exit = true;

////            } while (!exit);
////        }

////        public void AssignTaskToWorker(List<Task> TasksList, List<ITWorker> ItWorkersList)
////        {
////            Console.Clear();
////            Console.WriteLine("What task you want to assign?: (Select the number of task)");

////            foreach (var item in TasksList.Where(e => e.assigned == false))
////            {
////                Console.WriteLine($"Task:{item.IdTask} \n" +
////                    $"Task description: {item.Description}\n");
////            }

////            var answerTask = Convert.ToInt32(Console.ReadLine());

////            if (answerTask == 0)
////            {
////                Console.WriteLine("You need to choose the number of the task");

////            }

////            Task taskValue = TasksList.FirstOrDefault(e => e.IdTask == answerTask);



////            Console.WriteLine("Select the ID of the worker: ");

////            foreach (var item in ItWorkersList)
////            {
////                Console.WriteLine($"ID Worker:{item.ItWorkerId} \n" +
////                    $"Worker name: {item.Name}\n");
////            }

////            var answerWor = Convert.ToInt32(Console.ReadLine());

////            if (answerWor == 0)
////            {
////                Console.WriteLine("Error, Choose Id number of worker");
////            }

////            ITWorker workerVal = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWor);

////            taskValue.Worker = workerVal;

////            workerVal.TaskWorker = taskValue;

////            taskValue.assigned = true;


////            if (taskValue.StatusTask != Status.Done && workerVal.TechKnowledges.Contains(taskValue.Technology))
////            {


////                Console.WriteLine($"---------- Task Description Selected ----------");

////                taskValue.ShowValues();

////                Console.WriteLine("---------- Worker Description of task assigned ----------");

////                workerVal.ShowValues();

////            }
////            else Console.WriteLine("The worker need to Know the tech of the task, and the task cant be in State Done");
////        }
////    }
////}
