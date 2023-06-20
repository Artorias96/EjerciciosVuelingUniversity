using Domain.CustomExceptions;
using Domain.Entities;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServiceImplementations
{
    public class CarColorService : ICarColorService
    {
        private readonly ICarColorRepository _Repository;

        public CarColorService(ICarColorRepository repository)
        {
            _Repository = repository;
        }     

        public void Register(CarColor carInfo)
        {
            try
            {
                ValidateColor(carInfo.colorCar);
                ValidateInt(carInfo.percentage);

                _Repository.Insert(carInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateColor(string str)
        {
            if (str != "Red" && str != "Blue" && str != "Green")
            {
                throw new InvalidColorException(str);
            }
            return true;
        }

        private bool ValidateInt(int percentage)
        {
            if (percentage <= 0 || percentage > 100)
            {
                throw new InvalidIntException(percentage.ToString());
            }
            return true;
        }
    }
}
