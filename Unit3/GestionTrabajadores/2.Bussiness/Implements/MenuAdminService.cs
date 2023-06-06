using GestionTrabajadores._2.Bussiness.Contracts;
using GestionTrabajadores._3.Domain.IRepositories;
using GestionTrabajadores.Bussiness.Verifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionTrabajadores._2.Bussiness
{
    public class MenuAdminService : IMenuAdminService
    {

        ValidationsInputs verificateString = new ValidationsInputs();

        private readonly IRepositoryITWorker _repositoryWorker;
        private readonly IRepositoryTeam _repositoryTeam;
        private readonly IRepositoryTask _repositoryTask;

        public MenuAdminService(IRepositoryITWorker repositoryWorker, IRepositoryTeam repositoryTeam, IRepositoryTask _repositorytask)
        {
            _repositoryWorker = repositoryWorker;
            _repositoryTeam = repositoryTeam;
            _repositoryTask = _repositorytask;
        }

        public bool AddNewWorker(string name, string surName, DateTime dt, int yearsExperience,LevelWorker levelOfWorker, List<string> knowledges)
        {
            ITWorker worker = new ITWorker()
            {
                Name = name,
                Surname = surName,
                BirthDate = dt,
                LevelItWorker = levelOfWorker,
                yearsOfExperience = yearsExperience,
                TechKnowledges = knowledges             
            };
            _repositoryWorker.AddNewITWorker(worker);
            return true;
        }

        public ITWorker GetWorker(int id)
        {
            Worker worker = new Worker();
            {
                return _repositoryWorker.GetITWorker(id);
            }
            
        }

        public bool AddNewTeam(string teamName)
        {
            Team team = new Team()
            {
                TeamName = teamName
            };
            _repositoryTeam.AddNewTeam(team);
            return true; 
        }

        public bool AddNewTask(int id, string description, string technology)
        {
            Task task = new Task()
            {
                IdTask = id,
                Description = description,
                Technology = technology
            };
            _repositoryTask.AddNewTask(task);
            return true;
        }

        public List<Team> ListAllTeams()
        {
            return _repositoryTeam.ListAllTeams();
        }

        public List<Task> ListAllTasks()
        {
            return _repositoryTask.ListAllTasks();
        }

        public Worker GetWorkerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
