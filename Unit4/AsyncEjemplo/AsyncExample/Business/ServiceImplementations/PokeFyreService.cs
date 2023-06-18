using Business.ServiceContracts;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.Dtos;
using Infrastructure.RepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceImplementations
{
    public class PokeFyreService : IPokeFyreService
    {
 
        public async Task<PokeFyre> GetTypeFyreInfo()
        {
            PokeFyre result = await new PokeFyreRepository().TypeFyreInfo();

            return result;
        }
    }
}
