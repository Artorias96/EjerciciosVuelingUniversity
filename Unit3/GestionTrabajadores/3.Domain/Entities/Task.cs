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
        public int WorkerId { get; set; }
        public bool assigned {get; set; }
        public Status StatusTask { get; set; }

    }
}
