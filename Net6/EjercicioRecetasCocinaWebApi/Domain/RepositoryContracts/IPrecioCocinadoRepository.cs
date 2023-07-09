using Contracts.DomainEntitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
    public interface IPrecioCocinadoRepository
    {
        PrecioCocinado GetPrecioCocinado();
    }
}
