﻿using Domain.DomainEntities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.Dtos
{
    public class ProductListDto
    {
        public ProductList? productsInfoList { get; set; }
    }
}
