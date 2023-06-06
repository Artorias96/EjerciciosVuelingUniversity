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

        public string TeamNameWorker { get; set; }

        public int TaskWorkerId { get; set; }

        public int ItWorkerId { get; set; }

    }
}
