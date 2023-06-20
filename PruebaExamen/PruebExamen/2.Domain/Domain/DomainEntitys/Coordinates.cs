using Domain.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntitys
{
    public class Coordinates
    {
        public decimal coord1 { get; set; }
        public decimal coord2 { get; set; }
        public decimal coord3 { get; set; }

        public bool Validate()
        {
            //Validate coord1
            if (false)
            {
                throw new InvalidCoord1Exception(coord1.ToString());
            }
            //Validate coord2
            //Validate coord3
            return true;
        }
    }
}
