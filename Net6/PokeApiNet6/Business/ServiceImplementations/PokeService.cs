using Business.CustomExceptions;
using Business.ServiceContracts;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using Infrastructure.RepositoryImplementations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ServiceImplementations
{
    public class PokeService : IPokeService
    {
        private readonly IPokeMovesRepository _pokeMoveRepository;
        private readonly IPokeTypesRepository _pokeTypesRepository;
        private readonly IPokeTypeFyreRepository _pokeTypeFyreRepository;

        public PokeService(IPokeMovesRepository pokeMoveRepository, IPokeTypesRepository pokeTypesRepository, IPokeTypeFyreRepository pokeTypeFyreRepository)
        {

            _pokeMoveRepository = pokeMoveRepository;
            _pokeTypesRepository = pokeTypesRepository;
            _pokeTypeFyreRepository = pokeTypeFyreRepository;
        }
        public async Task<List<string>> GetMovesTypeFyreInfoInSpanish()
        {
            List<string> typeFyreInfo = await _pokeTypeFyreRepository.TypeFyreMoveInfo();

            List<string> movesInSpanish = new List<string>();
            foreach (string name in typeFyreInfo.Take(10))
            {

                MoveLanguageInfoList moveLanguageInfo = await _pokeMoveRepository.GetMovementsLanguageInfoByName(name);
                string nameInSpanish = moveLanguageInfo.GetMovementNameByLanguageId("es");

                movesInSpanish.Add(nameInSpanish);
            }

            string typeFyreMoveInSpainToJson = JsonConvert.SerializeObject(movesInSpanish);
            _pokeTypesRepository.SaveDataInFile(typeFyreMoveInSpainToJson);

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

            string typeFyrePokeToJson = JsonConvert.SerializeObject(pokeFistNames);
            _pokeTypesRepository.SaveDataInFile(typeFyrePokeToJson);

            return pokeFistNames;
        }

        public async Task<PokeTypeInfo> GetMovesAndPokesSelectedTypeInSpanish(string name)
        {

            PokeTypeInfo typeSelectedInfo = await _pokeTypesRepository.TypeSelectedMovesInfo(name);

            List<string> listMovesSpanish = new List<string>();

            foreach (string moveName in typeSelectedInfo.movesTypeSelected.Take(10))
            {
                MoveLanguageInfoList moveLanguageInfo = await _pokeMoveRepository.GetMovementsLanguageInfoByName(moveName);
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

            string typeSelectedInfoToJson = JsonConvert.SerializeObject(typeSelectedInfo);

            _pokeTypesRepository.SaveDataInFile(typeSelectedInfoToJson);

            return typeSelectedInfo;
        }

        public async Task<PokeTypeInfo> GetSelectedTypeMovesPokesInSelectedLanguage(string nameType, string language, int numberPoke)
        {

            PokeTypeInfo typeSelectedInfo = await _pokeTypesRepository.TypeSelectedMovesInfo(nameType);

            List<string> listMovesSpanish = new List<string>();

            foreach (string moveName in typeSelectedInfo.movesTypeSelected.Take(numberPoke))
            {
                MoveLanguageInfoList moveLanguageInfo = await _pokeMoveRepository.GetMovementsLanguageInfoByName(moveName);
                string nameInSpanish = moveLanguageInfo.GetMovementNameByLanguageId(language);

                listMovesSpanish.Add(nameInSpanish);
            }

            List<string> pokeNames = new List<string>();

            foreach (string namePoke in typeSelectedInfo.pokeTypeSelected.Take(numberPoke))
            {
                pokeNames.Add(namePoke);
            }

            typeSelectedInfo.pokeTypeSelected = pokeNames;
            typeSelectedInfo.movesTypeSelected = listMovesSpanish;

            string typeSelectedInfoToJson = JsonConvert.SerializeObject(typeSelectedInfo);

            _pokeTypesRepository.SaveDataInFile(typeSelectedInfoToJson);

            return typeSelectedInfo;

        }

        public bool ValidateCorrectPokeTypeName(string nameType)
        {
            if (!Regex.IsMatch(nameType, "^(grass|steel|fire|water|flying|rock|ice|fairy|shadow|normal|poison|bug|electric|dragon|unknown|fighting|ground|ghost|psychic|dark)$"))
            {
                throw new InvalidTypeNameException(nameType);
            }
            return true;
        }
        public bool ValidateCorrectLanguage(string language)
        {
            if (!Regex.IsMatch(language, "^(ja-Hrkt|roomaji|ko|zh-Hant|fr|de|es|it|en|cs|ja|zh-Hans|pt-BR)$"))
            {
                throw new InvalidLanguageException(language);
            }
            return true;
        }
        public bool ValidateCorrectNumberOfPokes(int numberPokes)
        {
            if (numberPokes <= 0 || numberPokes >= 20)
            {
                throw new InvalidNumberPokesException(Convert.ToString(numberPokes));
            }
            return true;
        }
    }
}
