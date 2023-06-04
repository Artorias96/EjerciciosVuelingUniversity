using GestionTrabajadores._3.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._2.Bussiness
{
    public class Login : ILogin
    {
        private IRepositoryITWorker _worker;
        private IRepositoryTeam _team;

        public Login(IRepositoryITWorker worker, IRepositoryTeam team) 
        {  
            _worker = worker;
            _team = team;
        }

        public string WorkerRoll(int id)
        {
            ITWorker worker = _worker.GetITWorker(id);

            return "";
        }

    }
}
