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

        private List<ITWorker> _ItWorkersList = new List<ITWorker>();
        private List<Task> _TasksList = new List<Task>();
        private List<Team> _Teams = new List<Team>();

        Assigneds assignedAs = new Assigneds();
        Registers register = new Registers();
        Deletes delete = new Deletes();
        ShowDetails details = new ShowDetails();

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

                            register.RegisterNewWorker(_ItWorkersList, Worker);

                            break;

                        case 2:

                            register.RegisterNewTeam(_Teams, Team);

                            break;

                        case 3:

                            register.RegisterNewTask(Task, _TasksList);


                            break;

                        case 4:

                            details.ShowTeamNames(_Teams);


                            break;

                        case 5:

                            assignedAs.AssignWorkerByTeam(_Teams, _ItWorkersList);

                            break;

                        case 6:

                            details.ShowUnassignedTask(_TasksList);
                            break;

                        case 7:

                            assignedAs.AssignedsTaskByTeam(_Teams, _TasksList);

                            break;

                        case 8:

                            assignedAs.AssignWorkerAsManager(_Teams, _ItWorkersList);

                            break;

                        case 9:

                            assignedAs.AssignWorkerAsTechnician(_Teams, _ItWorkersList);

                            break;

                        case 10:


                            assignedAs.AssignTaskToWorker(_TasksList, _ItWorkersList);


                            break;


                        case 11:

                            delete.DeleteWorker(_ItWorkersList);

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
