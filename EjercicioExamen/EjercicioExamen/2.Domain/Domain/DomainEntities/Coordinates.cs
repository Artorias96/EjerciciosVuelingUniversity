using Domain.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Coordinates
    {
        public decimal Coord1 { get; set; }
        public decimal Coord2 { get; set; }
        public decimal Coord3 { get; set; }

        public bool Validate()
        {
            //Validate coord1
            if (false)
            {
                throw new InvalidCoord1Exception(Coord1.ToString());
            }
            //Validate coord2
            //Validate coord3
            return true;
        }
    }
}
