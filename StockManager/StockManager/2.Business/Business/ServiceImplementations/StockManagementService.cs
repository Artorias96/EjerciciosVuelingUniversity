using Business.CustomExceptions;
using Business.RepositoryContracts;
using Business.ServiceContracts;
using Domain.EntitiesDomain;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceImplementations
{
    public class StockManagementService : IStockManagementService
    {
        private readonly IStockManagementRepository _Repository;
        private readonly IValidationService _ValidationService;

        public StockManagementService(IStockManagementRepository repository, IValidationService validation)
        {
            _Repository = repository;
            _ValidationService = validation;
        }

        public string Register(StockEntityDomain entity)
        {
            if(!_ValidationService.ValidateName(entity.StockName) || !_ValidationService.ValidateDescription(entity.StockDescription))
            {
                throw new OutOfRangeExceptions("ERROR, only 100 characters for name and 200 for description");
            }

            if (!_ValidationService.ValidateIdFormat(entity.StockId))
            {
                throw new WrongFormatException("Error, invalid format must be '000AAA'");
            }
           
              List<string> listStockDomain = _Repository.GetIds();

            if(listStockDomain.Count() > 0 && listStockDomain.Contains(entity.StockId))
            {
                return "Already Created";
            }

            listStockDomain.Add(entity);




                return "Everything go succesfull";
           
           
        }
    }
}
