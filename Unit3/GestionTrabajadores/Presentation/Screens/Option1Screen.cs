using GestionTrabajadores.Bussiness;
using GestionTrabajadores.Bussiness.Verifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation
{
    public class Option1Screen
    {
        Registers register = new Registers();
        public void Start(List<ITWorker> ItWorkersList, ITWorker worker)
        {
            register.RegisterNewWorker(ItWorkersList, worker);
            
        }
    }
}
