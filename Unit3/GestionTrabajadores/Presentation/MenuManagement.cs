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
        MainMenuRepository mainMenuRepository = new MainMenuRepository();

        private List<ITWorker> _ItWorkersList = new List<ITWorker>();
        private List<Task> _TasksList = new List<Task>();
        private List<Team> _Teams = new List<Team>();
        
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

        Task Task;

        Team Team;
        
        public void Start()
        {

            mainMenuRepository.CreateDataBase(_ItWorkersList, _Teams, _TasksList);

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

                            Option1Screen.Start(_ItWorkersList, Worker);
                           
                            break;

                        case 2:

                            Option2Screen.Start(_Teams, Team);

                            break;

                        case 3:

                            Option3Screen.Start(Task, _TasksList);


                            break;

                        case 4:

                            Option4Screen.Start(_Teams);


                            break;

                        case 5:

                            Option5Screen.Start(_Teams, _ItWorkersList);

                            break;

                        case 6:

                            Option6Screen.Start(_TasksList);
                            break;

                        case 7:

                            Option7Screen.Start(_Teams, _TasksList);

                            break;

                        case 8:

                            Option8Screen.Start(_Teams, _ItWorkersList);

                            break;

                        case 9:

                            Option9Screen.Start(_Teams, _ItWorkersList);

                            break;

                        case 10:


                            Option10Screen.Start(_TasksList, _ItWorkersList);


                            break;


                        case 11:

                            Option11Screen.Start(_ItWorkersList);
                            
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
