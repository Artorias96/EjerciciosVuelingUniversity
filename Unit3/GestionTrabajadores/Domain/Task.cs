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
        public static int idTaskIncrement { get; set; }
        public ITWorker Worker { get; set; }
        public bool assigned {get; set; }
        public Status StatusTask { get; set; }
        public Team TeamTask { get; set; }

        public Task(string description, string tech, Status status)
        {
            idTaskIncrement++;
            IdTask = idTaskIncrement;
            Description = description;
            Technology = tech;  
            StatusTask = status;
        }

        public void ShowValues()
        {
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Tech: {Technology}");
            Console.WriteLine($"Status of the task: {StatusTask}");

        }

    }
}
