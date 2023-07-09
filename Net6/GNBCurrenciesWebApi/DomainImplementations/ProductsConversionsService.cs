using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using DomainContracts.ServiceContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainImplementations
{
    public class ProductsConversionsService : IProductsConversionsService
    {
        private readonly IProductsConversionsRepository _productsConversionsRepository;
        private readonly IConversionsRepository _conversionsRepository;

        public ProductsConversionsService(IProductsConversionsRepository productsConversionsRepository, IConversionsRepository conversionsRepository)
        {
            _productsConversionsRepository = productsConversionsRepository;
            _conversionsRepository = conversionsRepository;
        }
        public async Task <List<ProductsConversions>>GetAllProductsConversions(string sku)
        {
            List<ProductsConversions> productsConversionsList = await _productsConversionsRepository.GetAll();

            List<Conversions> conversionsList = await _conversionsRepository.GetAll();

            SaveDataInLocalFiles(conversionsList, productsConversionsList);

            List<ProductsConversions> listOfTranslationsFiltered = productsConversionsList.Where(x => x.Sku == sku).ToList();

            if (listOfTranslationsFiltered == null) return null;

            foreach (var item in listOfTranslationsFiltered)
            {
                if(item.Currency != "EUR")
                {
                    Conversions conversionSelected = conversionsList.FirstOrDefault(x => x.From == item.Currency);

                    item.Amount *= conversionSelected.rate;
                    item.Currency = "EUR";
                }
                
            }

            return (listOfTranslationsFiltered);
        }

        private void SaveDataInLocalFiles(List<Conversions> conversionsList, List<ProductsConversions> productsConversionsList)
        {
            _conversionsRepository.SaveConversionsInFile(conversionsList);
            _productsConversionsRepository.SaveProductsConversionsInFile(productsConversionsList);
        }
    }
}
