using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._3.Domain.IRepositories
{
    public interface IRepositoryTeam
    {
        bool AddNewTeam(Team team);

        Team GetTeam(string TeamName);

        bool DeleteTeam(Team team);
    }
}
