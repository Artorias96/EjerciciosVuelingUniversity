using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores.Presentation.Screens
{
    public class Option2Screen
    {
        Registers register = new Registers();

        public void Start(List<Team> Teams, Team team)
        {
            register.RegisterNewTeam(Teams, team);
        }
    }
}
