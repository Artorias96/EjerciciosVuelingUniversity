using Business.ServiceContracts;
using Business.ServiceRepository;
using Domain.DomainEntities;
using Domain.RepositoryContracts;
using DTOs;
using Moq;

namespace UnitTestProductsWebApi
{
    public class ProductServiceUnitTest
    {
        private readonly Mock<IProductsRepository> _productsRepository;
        private readonly Mock<ITranslationsRepository> _TranslationsRepository;

        private readonly IProductService _productService;

        public ProductServiceUnitTest()
        {
            _productsRepository = new Mock<IProductsRepository>();
            _TranslationsRepository = new Mock<ITranslationsRepository>();

            _productService = new ProductService(_productsRepository.Object, _TranslationsRepository.Object);
        }
        [Fact]
        public void When_GetAllProductsTranslationsByLanguage_ReturnCorrectValue()
        {
            //Arrange
            string language = "EN";
            List<ProductByLanguageDTO> productsDtoFilteredByLanguage = new List<ProductByLanguageDTO>
            {
                new ProductByLanguageDTO
                {
                    Name = "Product one",
                    Precio = "12,34€",
                    ratio = "7/10"
                }
            };
            List<Products> productsFilteredByLanguage = new();
            Products product1 = new Products { Id = 1, Price = 12.34m, Rate = "7", Discontinued = "no" };
            productsFilteredByLanguage.Add(product1);
            Products product2 = new Products { Id = 2, Price = 21.43m, Rate = "8", Discontinued = "no" };
            productsFilteredByLanguage.Add(product2);
            Products product3 = new Products { Id = 3, Price = 23.45m, Rate = "6", Discontinued = "yes" };
            productsFilteredByLanguage.Add(product3);
            List<ProductTranslations> listOfTranslations = new();
            ProductTranslations translations1 = new ProductTranslations
            {
                IdProduct = 1,
                Translations = new Dictionary<string, string>(){
                {"ES", "Producto uno"},
                {"EN", "Product one"},
                {"FR", "Produit un"} }
            };
            listOfTranslations.Add(translations1);
            _productsRepository.Setup(x => x.GetAll()).Returns(productsFilteredByLanguage);
            _TranslationsRepository.Setup(x => x.GetAll()).Returns(listOfTranslations);
            _productsRepository.Setup(x => x.GetProductById(product1.Id)).Returns(product1);

            //Act

            List<ProductByLanguageDTO> result = _productService.GetAllProductsTranslationsByLanguage(language);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Any(e => e.Name.Equals(productsDtoFilteredByLanguage.FirstOrDefault().Name)));
            Assert.True(result.Any(e => e.Precio.Equals(productsDtoFilteredByLanguage.FirstOrDefault().Precio)));
            Assert.True(result.Any(e => e.ratio.Equals(productsDtoFilteredByLanguage.FirstOrDefault().ratio)));
        }
    }
}