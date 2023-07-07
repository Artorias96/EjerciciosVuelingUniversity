using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IProductsRepository
    {
        List<Products> GetAll();
        Products GetProductById(int id);
    }
}
