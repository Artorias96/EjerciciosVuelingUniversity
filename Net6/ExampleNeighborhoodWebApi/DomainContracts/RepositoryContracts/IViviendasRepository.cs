using DomainContracts.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.RepositoryContracts
{
    public interface IViviendasRepository
    {
        Task<List<Viviendas>> GetAll();
        void SaveViviendasInFile(List<Viviendas> listOfConversions);
    }
}
