using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option9Screen
    {
        public void Start(List<Team> Teams, List<ITWorker> ItWorkersList)
        {
            Console.Clear();

            bool exit = false;
            do
            {
                Console.WriteLine("Select team by team name");

            foreach (var item in Teams)
            {
                Console.WriteLine($"Team: {item.TeamName}");
            }

            var answertech = Console.ReadLine();

            if (answertech == null)
            {
                Console.WriteLine("Error, the name dosen´t exit");
            }

            Team teamTech = Teams.FirstOrDefault(e => e.TeamName == answertech);


            Console.WriteLine("Select the worker to add as technician by number of ID");

            foreach (var item in ItWorkersList)
            {
                Console.WriteLine($"IdWorker: {item.ItWorkerId}");
            }

            var answerWorkerTech = Convert.ToInt32(Console.ReadLine());

            if (answerWorkerTech == 0)
            {
                Console.WriteLine("Please select a ID number that exists");
            }

            ITWorker workerTech = ItWorkersList.FirstOrDefault(e => e.ItWorkerId == answerWorkerTech);

            workerTech.TeamWorker = teamTech;

            teamTech.Technicians.Add(workerTech);

            Console.WriteLine($"Team: {teamTech.TeamName}");

            Console.WriteLine("----------Worker Added As Technician Description----------");

            workerTech.ShowValues();

                exit = true;

            } while (!exit);
        }
    }
}
