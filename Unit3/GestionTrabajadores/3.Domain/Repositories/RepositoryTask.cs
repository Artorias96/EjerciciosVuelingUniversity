using GestionTrabajadores;
using GestionTrabajadores._3.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._3.Domain.Repositories
{
    public class RepositoryTask : IRepositoryTask
    {
        private List<Task> _tasksList;

        public RepositoryTask()
        {
            _tasksList = new List<Task>()
            {
                new Task(1,"Task number 1", "C#", Status.ToDo),
                new Task(2,"Task number 2", "Python", Status.Doing),
                new Task(3,"Task number 3", "php", Status.Done)
            };
        }

        public bool AddNewTask(Task task)
        {
            try
            {
                _tasksList.Add(task);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteTask(Task task)
        {
            try
            {
                return _tasksList.Remove(task);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task GetTask(int taskID)
        {
            try
            {
                return _tasksList.FirstOrDefault(e => e.IdTask == taskID);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
