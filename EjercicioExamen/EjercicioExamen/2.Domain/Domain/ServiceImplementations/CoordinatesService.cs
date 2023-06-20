using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServiceImplementations
{
    public class CoordinatesService : ICoordinatesService
    {
        private readonly ICoordinatesRepository _repository;

        public CoordinatesService(ICoordinatesRepository repository)
        {
            _repository = repository;
        }

        public void Register(Coordinates coords)
        {

            coords.Validate();

            _repository.Insert(coords);

        }

        public List<string> GetList()
        {
            return _repository.GetList();
        }
    }
}
