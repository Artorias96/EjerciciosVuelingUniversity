using Business.ServiceContracts;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ServiceRepository
{
    public class ProductService :IProductService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ITranslationsRepository _translationsRepository;
        private readonly ICacheRepository _cacheRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductsRepository productsRepository, ITranslationsRepository translationsRepository, ICacheRepository cacheRepository, ILogger<ProductService> logger)
        {
            _productsRepository = productsRepository;
            _translationsRepository = translationsRepository;
            _cacheRepository = cacheRepository;
            _logger = logger;
        }

        public List<ProductByLanguageDTO> GetAllProductsTranslationsByLanguage(string language)
        {
            // Antes de obtener los productos, verifica si hay una caché válida y la utiliza
            var cachedProductInfoList = _cacheRepository.GetCache<ProductByLanguageDTO>("productInfoListKey");
            if (cachedProductInfoList != null)
            {
                return cachedProductInfoList;
            }

            List<ProductByLanguageDTO> productsFilteredByLanguage = new();

            List<ProductTranslations> listOfTranslationsFiltered = GetListFilteredByLanguage(language);

            foreach (var item in listOfTranslationsFiltered)
            {
                Products productFromTranslation = _productsRepository.GetProductById(item.IdProduct);

                if (productFromTranslation == null) return null;

                if (productFromTranslation.Discontinued == "no")
                {
                    var productDto = new ProductByLanguageDTO
                    {
                        Name = item.Translations[language],
                        Precio = $"{productFromTranslation.Price}€",
                        ratio = $"{productFromTranslation.Rate}/10",
                    };
                    productsFilteredByLanguage.Add(productDto);
                }
            }

            // Guarda los productos en la caché
            _cacheRepository.SetCache<ProductByLanguageDTO>("productInfoListKey", productsFilteredByLanguage);

            return productsFilteredByLanguage;
        }

        private List<ProductTranslations> GetListFilteredByLanguage(string language)
        {
            List<ProductTranslations> listOfTranslations = _translationsRepository.GetAll();

            List<ProductTranslations> listOfTranslationsFiltered = listOfTranslations.Where(x => x.Translations.ContainsKey(language)).ToList();
            return listOfTranslationsFiltered;
        }

        public bool ValidateCorrectLanguage(string str)
        {
            if (!Regex.IsMatch(str, "^(ES|EN|FR)$"))
            {
                return false;
            }
            return true;
        }
    }
}
