using Domain.Entities;
using Domain.RepositoryContracts;
using Infrastructure.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class CarColorRepository : ICarColorRepository
    {
        private readonly string _localDbRelPath;

        public CarColorRepository()
        {
            _localDbRelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "CarColorInfo.txt");
        }

        public void Insert(CarColor carInfo)
        {

            var carColorDto = new CarColorDTO()
            {
                colorCar = carInfo.colorCar,
                marca = carInfo.marca,
                percentage = carInfo.percentage,
                DateTime = DateTime.UtcNow
            };

            string DbAsList = File.ReadAllText(_localDbRelPath);
            //string dataToInsert = $" Color of car: {carInfo.colorCar}\n Color%: {carInfo.percentage}\n Marca: {carInfo.marca}\n added on: {DateTime.UtcNow}";
            List<CarColorDTO> listCarsDto = new List<CarColorDTO>();  
            
            if(DbAsList == "" ) 
            {
                listCarsDto = new List<CarColorDTO>();
            }
            else
            {
                listCarsDto = JsonConvert.DeserializeObject<List<CarColorDTO>>(DbAsList);
            }

            listCarsDto.Add(carColorDto);

            string listToJson = JsonConvert.SerializeObject(listCarsDto);

            File.WriteAllText(_localDbRelPath, listToJson);
        }
    }
}
