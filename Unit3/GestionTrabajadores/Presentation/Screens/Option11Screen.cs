using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option11Screen
    {
        Deletes delete = new Deletes();
        public void Start(List<ITWorker> ItWorkersList)
        {
            delete.DeleteWorker(ItWorkersList);
        }
    }
}
