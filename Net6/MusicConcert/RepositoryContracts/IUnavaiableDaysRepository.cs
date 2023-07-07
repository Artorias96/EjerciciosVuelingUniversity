using Domain.Agregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IUnavaiableDaysRepository
    {
        UnavaiableDaysList GetAll();
    }
}
