using GestionTrabajadores._3.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionTrabajadores._3.Domain.Repositories
{
    public class RepositoryITWorker : IRepositoryITWorker
    {
        private List<ITWorker> _iTWorkerList;
        public RepositoryITWorker()
        {
            _iTWorkerList = new List<ITWorker>()
            {   new ITWorker(){Name = "Paco",Surname= "Jones",BirthDate = new DateTime(1990, 7, 12), yearsOfExperience = 5,LevelItWorker = LevelWorker.Senior,TechKnowledges = new List<string> { "C#", "ASP.NET", "SQL" }},
                new ITWorker(){Name = "Elber", Surname= "Gadura", BirthDate  = new DateTime(1998, 4, 9), yearsOfExperience = 2, LevelItWorker = LevelWorker.Junior, TechKnowledges =  new List<string> { "Python", "Java", "HTML" } },
                new ITWorker(){Name = "Rosa",  Surname= "Melano", BirthDate  = new DateTime(2000, 4, 26), yearsOfExperience = 3,  LevelItWorker = LevelWorker.Medium, TechKnowledges = new List<string> { "C++", "JavaScript", "php" }}
            };

        }
        public bool AddNewITWorker(ITWorker iTWorker)
        {
            try
            {
                _iTWorkerList.Add(iTWorker);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteITWorker(ITWorker iTWorker)
        {
            try
            {
                return _iTWorkerList.Remove(iTWorker);            
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ITWorker GetITWorker(int iTWorkerID)
        {
            try
            {
               return _iTWorkerList.FirstOrDefault(e => e.ItWorkerId == iTWorkerID);
               
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
