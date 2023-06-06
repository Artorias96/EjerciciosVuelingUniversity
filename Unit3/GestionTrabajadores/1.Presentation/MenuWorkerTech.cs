using GestionTrabajadores._3.Domain.IRepositories;
using GestionTrabajadores.Bussiness.Verifications;
using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._1.Presentation
{
    public class MenuWorkerTech
    {
        ValidationsInputs verificateString = new ValidationsInputs();

        private IRepositoryITWorker _worker;
        private IRepositoryTask _task;
        private IRepositoryTeam _team;


        Registers register = new Registers();
        Deletes delete = new Deletes();
        ShowDetails details = new ShowDetails();

        ITWorker Worker;
        Task Task;
        Team Team;

        public void MenuWorkerManagement()
        {
            bool exit = false;

            string separator = "-------------------------------------------------------------------------------------------------------------------";
            string messageMenu = "Select one of the options \n 6. List unassigned tasks \n 7. List task assignments by team name \n 10. Assign task to IT worker \n 12. Exit";
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

                        case 6:

                            //details.ShowUnassignedTask(_TasksList);
                            break;

                        case 7:

                            //assignedAs.AssignedsTaskByTeam(_Teams, _TasksList);

                            break;

                        case 10:

                            //assignedAs.AssignTaskToWorker(_TasksList, _ItWorkersList);

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
