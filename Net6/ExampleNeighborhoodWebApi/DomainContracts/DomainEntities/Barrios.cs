using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainContracts.DomainEntities
{
    public class Barrios
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CosteM2 { get; set; }
    }
}
