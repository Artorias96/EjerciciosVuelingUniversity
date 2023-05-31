using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class MenuManagement
    {
        public List<ITWorker> ItWorkersList = new List<ITWorker>();
        public List<Task> TasksList = new List<Task>();
        public List<Team> Teams = new List<Team>();
        public void Start()
        {


            Builder builderObjects = new Builder();

            Team team;
            ITWorker worker;
            Task task;

            bool exit = false;

            string messageMenu = "Welcome to the worker management application \n Select one of the options \n 1. Register new IT worker \n 2. Register new team \n 3.Register new task(unassigned to anyone)" +
                " \n 4. List all team names \n 5. List team members by team name \n 6. List unassigned tasks \n 7. List task assignments by team name \n 8. Assign ITworker to a team as manager \n 9. Assign IT worker to a team as technician" +
                "\n 10. Assign task to IT worker \n 11. Unregister worker \n 12. Exit";
            string optionNotValidError = "Error, you have to choose one of the options between 1-12";

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

                            ItWorkersList.Add(worker);


                            break;

                        case 2:
                            Console.WriteLine("Introduce the name of the team you want to add");
                            string nameOfTeam = Console.ReadLine();

                            team = new Team(nameOfTeam);

                            Teams.Add(team);

                            break;

                        case 3:

                            Console.WriteLine("Introduce description of the new task");
                            string description = Console.ReadLine();

                            Console.WriteLine("Introduce the technology to use");
                            string technology = Console.ReadLine();

                            Console.WriteLine("Introduce Id for the task");
                            int idtask = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Introduce state of task \n 1-ToDo \n 2-Doing \n 3-Done");
                            var status = Convert.ToInt32(Console.ReadLine());

                            task = new Task(description, technology, idtask, (Status)status);

                            TasksList.Add(task);


                            break;

                        case 4:

                            Console.WriteLine($"List of all Team names: ");

                            foreach (var item in Teams)
                            {
                                Console.WriteLine($"Nombre del equipo: {item.TeamName}\n");
                            }

                            Teams.ForEach(Console.WriteLine);

                            break;

                        case 5:

                            //Console.WriteLine("Choose the team Name: ");



                            break;

                        case 6:
                            break;

                        case 7:
                            break;

                        case 8:
                            break;

                        case 9:
                            break;

                        case 10:

                            break;


                        case 11:
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

                Console.WriteLine("¿Alguno mas? si/no");
                var moreEntry = Console.ReadLine();
                if (moreEntry == "no")
                {
                    more = false;
                }
                else if (moreEntry != "si" || moreEntry != "no")
                {
                    Console.WriteLine("intruzca valor correcto");
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
            var worker = ItWorkersList.Where(ITWorker => ITWorker.ItWorkerId == id).FirstOrDefault();
            // or simply
            // var book = books.FirstOrDefault(book => book.author == search);
            return worker;
        }

        public Team GetTeamName(string name)
        {
            var team = Teams.Where(Team => Team.TeamName == name).FirstOrDefault();

            return team;
        }


        //Console.WriteLine("Lista de Alumnos: ");

        //foreach (var item in ItWorkersList)
        //{
        //    Console.WriteLine($"Nombre: {item.Name} \n" +
        //        $"Surname: {item.Surname} \n" +
        //        $"Birthday: {item.BirthDate}\n" +
        //        $"Years experience: {item.yearsOfExperience}\n" +
        //        $"Level of worker: {item.LevelItWorker} \n" +
        //        $"Knowledges of worker: {item.techKnowledges}");
        //}
    }
}
