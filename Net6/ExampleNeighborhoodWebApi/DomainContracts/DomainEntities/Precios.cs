using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
        public class Precios
        {
            public Dictionary<string, CondicionesCoste> Añadidos { get; set; }
        }

        public class CondicionesCoste
        {
            public decimal PrecioM2 { get; set; }
            public decimal Precio { get; set; }

        }
    
}
