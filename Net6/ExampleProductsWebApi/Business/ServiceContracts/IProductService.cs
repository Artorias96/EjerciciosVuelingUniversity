using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IProductService
    {
        List<ProductByLanguageDTO> GetAllProductsTranslationsByLanguage(string language);
        bool ValidateCorrectLanguage(string str);
    }
}
