using GestionTrabajadores._3.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._3.Domain.Repositories
{
    public class RepositoryITWorker : IRepositoryITWorker
    {
        private List<ITWorker> _iTWorkerList;
        public RepositoryITWorker()
        {
            _iTWorkerList = new List<ITWorker>()
            {   new ITWorker("Paco", "Jones", new DateTime(1990, 7, 12), 5, LevelWorker.Senior, new List<string> { "C#", "ASP.NET", "SQL" }),
                new ITWorker("Elber", "Gadura", new DateTime(1998, 4, 9), 2, LevelWorker.Junior, new List<string> { "Python", "Java", "HTML" }),
                new ITWorker("Rosa", "Melano", new DateTime(2000, 4, 26), 3, LevelWorker.Medium, new List<string> { "C++", "JavaScript", "php" })
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
