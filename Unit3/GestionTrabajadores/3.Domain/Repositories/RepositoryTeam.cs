using GestionTrabajadores._3.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._3.Domain.Repositories
{
    public class RepositoryTeam : IRepositoryTeam
    {
        private List<Team> _teamsList;

        public RepositoryTeam()
        {
            _teamsList = new List<Team>()
            {
            new Team("Team Paco"),
            new Team("Team Elber"),
            new Team("Team Rosa")
            };
        }

        public bool AddNewTeam(Team team)
        {
            try
            {
                _teamsList.Add(team);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteTeam(Team team)
        {
            try
            {
                return _teamsList.Remove(team);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Team GetTeam(string TeamName)
        {
            try
            {
                return _teamsList.FirstOrDefault(e => e.TeamName == TeamName);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
