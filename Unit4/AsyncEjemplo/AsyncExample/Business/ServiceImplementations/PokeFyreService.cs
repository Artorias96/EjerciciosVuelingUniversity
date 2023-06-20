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
        private readonly IPokeTypeRepository _pokeTypeRepository;
        private readonly IPokeMoveRepository _pokeMoveRepository;

        public PokeFyreService(IPokeTypeRepository repository, IPokeMoveRepository pokeMoveRepository)
        {
            _pokeTypeRepository = repository;
            _pokeMoveRepository = pokeMoveRepository;
        }

        public async Task<List<string>> GetTypeFyreInfoInSpanish()
        {
            List<string> typeFyreInfo = await _pokeTypeRepository.TypeFyreInfo();

            List<string> movesInSpanish = new List<string>();
            foreach (string name in typeFyreInfo.Take(10))
            {

                MoveLanguageInfoList moveLanguageInfo = await _pokeMoveRepository.GetMovementsLanguageInfoById(name);
                string nameInSpanish = moveLanguageInfo.GetMovementNameByLanguageId("es");

                movesInSpanish.Add(nameInSpanish);
            }

            return movesInSpanish;
        }
    }
}
