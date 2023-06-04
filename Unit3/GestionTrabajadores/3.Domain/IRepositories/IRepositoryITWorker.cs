using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._3.Domain.IRepositories
{
    public interface IRepositoryITWorker
    {
        bool AddNewITWorker(ITWorker iTWorker);

        ITWorker GetITWorker(int iTWorkerID);

        bool DeleteITWorker(ITWorker iTWorker);
    }
}
