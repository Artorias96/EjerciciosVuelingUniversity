using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class Task
    {
        public string Description { get; set; }

        public string Technology { get; set; }

        public int IdTask { get; set; }

        public int IdWorker { get; set; }
        //objeto itworker
        public ITWorker Worker { get; set; }

        public Status StatusTask { get; set; }

        public Task(string description, string tech, int id, Status status)
        {
            Description = description;
            Technology = tech;
            IdTask = id;
            StatusTask = status;
        }

    }
}
