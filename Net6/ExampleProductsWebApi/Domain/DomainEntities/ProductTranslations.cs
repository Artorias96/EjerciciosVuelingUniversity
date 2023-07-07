using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class ProductTranslations
    {
        public int IdProduct { get; set; }

        public Dictionary<string,string> Translations { get; set; }
    }
}
