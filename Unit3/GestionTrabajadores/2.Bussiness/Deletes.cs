using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Bussiness
{
    public class Deletes : IDeletes
    {
        public void DeleteTeam(List<string> TeamName)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorker(List<ITWorker> ItWorkersList)
        {
            Console.Clear();
            Console.WriteLine("Select by ID the worker to unsubscribe");

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


            Console.WriteLine("---------- Worker unregistered Description ----------");

            workerRemoved.ShowValues();

            Console.WriteLine($"day of worker unregistered : {workerRemoved.LeavingDate}");
        }
    }
}
