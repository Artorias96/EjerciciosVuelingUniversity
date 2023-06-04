using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._3.Domain.IRepositories
{
    public interface IRepositoryTask
    {
        bool AddNewTask(Task task);

        Task GetTask(int taskID);

        bool DeleteTask(Task task);
    }
}
