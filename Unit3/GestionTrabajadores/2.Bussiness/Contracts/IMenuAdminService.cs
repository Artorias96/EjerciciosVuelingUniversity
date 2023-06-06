using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._2.Bussiness.Contracts
{
    public interface IMenuAdminService
    {
        bool AddNewWorker(string name, string surName, DateTime dt, int yearsExperience, LevelWorker levelOfWorker, List<string> knowledge);
        bool AddNewTeam(string teamName);
        bool AddNewTask(int id, string description, string technology);
        List<Team> ListAllTeams();

        List<Task> ListAllTasks();  
        
        Worker GetWorkerById(int id);
    }
}
