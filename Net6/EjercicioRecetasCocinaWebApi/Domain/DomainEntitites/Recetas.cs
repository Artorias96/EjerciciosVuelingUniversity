using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainEntitites
{
    public class Recetas
    {
        public string Nombre { get; set; }
        public Dictionary<string, decimal> Ingredientes { get; set; }
        public int MinutosCocinando { get; set; }
    }
}
