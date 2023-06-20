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
    public class PokeService : IPokeService
    {
        private readonly IPokeTypeFyreRepository _pokeTypeFyreRepository;
        private readonly IPokeMoveRepository _pokeMoveRepository;
        private readonly IPokeTypesRepository _pokeTypesRepository;

        public PokeService(IPokeTypeFyreRepository repository, IPokeMoveRepository pokeMoveRepository, IPokeTypesRepository pokeTypesRepository)
        {
            _pokeTypeFyreRepository = repository;
            _pokeMoveRepository = pokeMoveRepository;
            _pokeTypesRepository = pokeTypesRepository;
        }

        public async Task<List<string>> GetMovesTypeFyreInfoInSpanish()
        {
            List<string> typeFyreInfo = await _pokeTypeFyreRepository.TypeFyreMoveInfo();

            List<string> movesInSpanish = new List<string>();
            foreach (string name in typeFyreInfo.Take(10))
            {

                MoveLanguageInfoList moveLanguageInfo = await _pokeMoveRepository.GetMovementsLanguageInfoById(name);
                string nameInSpanish = moveLanguageInfo.GetMovementNameByLanguageId("es");

                movesInSpanish.Add(nameInSpanish);
            }

            return movesInSpanish;
        }

        public async Task<List<string>> GetPokeNames()
        {
            List<string> typeFyrePokeInfo = await _pokeTypeFyreRepository.TypeFyrePokeInfo();

            List<string> pokeFistNames = new List<string>();

            foreach (string name in typeFyrePokeInfo.Take(10))
            {
                pokeFistNames.Add(name);
            }

            return pokeFistNames;
        }
        public async Task<PokeTypeInfo> GetMovesAndPokesSelectedTypeInSpanish(string name)
        {
            PokeTypeInfo typeSelectedInfo = await _pokeTypesRepository.TypeSelectedMovesInfo(name);

            List<string> listMovesSpanish = new List<string>();

            foreach (string Ids in typeSelectedInfo.movesTypeSelected.Take(10))
            {
                MoveLanguageInfoList moveLanguageInfo = await _pokeMoveRepository.GetMovementsLanguageInfoById(Ids);
                string nameInSpanish = moveLanguageInfo.GetMovementNameByLanguageId("es");

                listMovesSpanish.Add(nameInSpanish);
            }

            List<string> pokeNames = new List<string>();

            foreach (string namePoke in typeSelectedInfo.pokeTypeSelected.Take(10))
            {
                pokeNames.Add(namePoke);
            }

            typeSelectedInfo.pokeTypeSelected = pokeNames;
            typeSelectedInfo.movesTypeSelected = listMovesSpanish;

            _pokeTypesRepository.SaveDataInFile(pokeNames);
            _pokeTypesRepository.SaveDataInFile(listMovesSpanish);


            return typeSelectedInfo;
        }
    }
}
