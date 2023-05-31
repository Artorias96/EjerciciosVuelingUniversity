using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    public class ITWorker : Worker
    {

        public int yearsOfExperience { get; set; }

        public LevelWorker LevelItWorker { get; set; }

        public List<string> TechKnowledges = new List<string>();

        public Team TeamWorker { get; set; }

        public Task TaskWorker { get; set; }

        public int ItWorkerId { get; set; }


        public ITWorker(string nameItworker, string surnameItworker, DateTime birthDayItworker, int yearsOfExperienceItworker, LevelWorker level,
           List<string> techKnowledges) : base(nameItworker, surnameItworker, birthDayItworker)
        {
            ItWorkerId = Worker.Id;
            yearsOfExperience = yearsOfExperienceItworker;
            LevelItWorker = level;
            this.TechKnowledges = techKnowledges;
        }

        public void AssignTaskToItWorker(Task task)
        {
            TaskWorker = task;
        }
    }
}
