using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface ICoordinatesRepository
    {
        void Insert(Coordinates coords);
        List<string> GetList();
    }
}
