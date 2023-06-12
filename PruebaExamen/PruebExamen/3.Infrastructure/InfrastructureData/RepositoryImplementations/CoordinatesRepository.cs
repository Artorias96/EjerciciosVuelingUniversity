using Domain.DomainEntitys;
using Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    
    public class CoordinatesRepository : ICoordinatesRepository
    {
        private readonly string _localDbRelPath;

        public CoordinatesRepository()
        {
            _localDbRelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "Coordinates.txt");
        }

        public void Insert(Coordinates coords)
        {
            List<string> DbAsList = File.ReadAllLines(_localDbRelPath).ToList();
            string dataToInsert = $"Coords {coords.coord1}, {coords.coord2}, {coords.coord3} added on {DateTime.UtcNow}";

            DbAsList.Add(dataToInsert);

            File.WriteAllLines(_localDbRelPath, DbAsList);
        }

        public List<string> GetList()
        {
            List<string> DbAsList = File.ReadAllLines(_localDbRelPath).ToList();
            
            return DbAsList;
        }
    }
}
