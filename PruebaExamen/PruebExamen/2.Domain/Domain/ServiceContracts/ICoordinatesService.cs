﻿using Domain.DomainEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServiceContracts
{
    public interface ICoordinatesService
    {
        void Register(Coordinates coords);

        List<string> GetList();
    }
}
