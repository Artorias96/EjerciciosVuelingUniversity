using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option8Screen
    {
        public void Start(List<Team> Teams, List<ITWorker> ItWorkersList)
        {
            Console.Clear();

            bool exit = false;
            do
            {
                Console.WriteLine("Choose the name of the team to add a manager: ");

                foreach (var item in Teams)
                {
                    Console.WriteLine($"Team: {item.TeamName}");
                }
                var answerteam = Console.ReadLine();

                if (answerteam == null)
                {
                    Console.WriteLine("Please entry a real name");
                    break;
                }

                Team teammanager = Teams.FirstOrDefault(e => e.TeamName == answerteam);

                Console.WriteLine("Select the Number of the worker to add as manager");

                foreach (var item in ItWorkersList)
                {
                    Console.WriteLine($"Worker Id: {item.ItWorkerId}");
                }

                var answerworker = Convert.ToInt32(Console.ReadLine());

                if (answerworker == 0)
                {
                    Console.WriteLine("Error, choose the number of the worker");
                    break;
                }

                ITWorker workermanager = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerworker);

                workermanager.TeamWorker = teammanager;

                teammanager.Manager = workermanager;

                Console.WriteLine($"Team: {teammanager.TeamName}");

                Console.WriteLine("----------Worker Added As Manager Description----------");

                workermanager.ShowValues();

                exit = true;

            } while (!exit);
        }
    }
}
