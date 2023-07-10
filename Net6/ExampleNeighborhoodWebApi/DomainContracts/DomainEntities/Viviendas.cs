using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class Viviendas
    {
        public int Id { get; set; }
        public int IdBarrio { get; set; }
        public decimal M2 { get; set; }
        public Dictionary<string, decimal> Añadidos { get; set; }
    }
}
