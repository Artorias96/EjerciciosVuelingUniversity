using Domain;
using Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
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
            string dataToInsert = $"Coords {coords.Coord1}, {coords.Coord2}, {coords.Coord3} added on {DateTime.UtcNow}";

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
