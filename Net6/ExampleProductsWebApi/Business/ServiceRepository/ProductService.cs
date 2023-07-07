using Business.ServiceContracts;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using DTOs;
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

        public ProductService(IProductsRepository productsRepository, ITranslationsRepository translationsRepository)
        {
            _productsRepository = productsRepository;
            _translationsRepository = translationsRepository;
        }

        public List<ProductByLanguageDTO> GetAllProductsTranslationsByLanguage(string language)
        {
            List<ProductByLanguageDTO> productsFilteredByLanguage = new();

            List<Products> listOfProducts = _productsRepository.GetAll();
            
            List<ProductTranslations> listOfTranslations = _translationsRepository.GetAll();

            List<ProductTranslations> listOfTranslationsFiltered = listOfTranslations.Where(x => x.Translations.ContainsKey(language)).ToList();

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
            return productsFilteredByLanguage;
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
