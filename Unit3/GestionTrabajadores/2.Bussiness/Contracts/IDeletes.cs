using System.Collections.Generic;

namespace GestionTrabajadores.Bussiness
{
    public interface IDeletes
    {
        void DeleteWorker(List<ITWorker> ItWorkersList);

        void DeleteTeam(List<string> TeamName);

    }
}