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
              new Task(){IdTask = 1, Description = "Task number 1", Technology = "C#"},
              new Task(){IdTask = 2, Description = "Task number 2", Technology = "Python"},
              new Task(){IdTask = 3, Description = "Task number 3", Technology = "SQL"},
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

        public List<Task> ListAllTasks() 
        {
            return _tasksList;
        }
    }
}
