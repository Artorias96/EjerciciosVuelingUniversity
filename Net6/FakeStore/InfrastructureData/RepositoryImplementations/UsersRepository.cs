using Domain.DomainEntities.UserEntities;
using Domain.RepositoryContracts;
using InfrastructureData.DataEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData.RepositoryImplementations
{
    public class UsersRepository : IUsersRepository
    {
        private StreamWriter? _localDbRelPath;

        private const string _routeFile = "C:\\Users\\Hola\\VisualStudio\\EjerciciosVuelingUniversity\\Net6\\FakeStore\\InfrastructureData\\LocalFiles\\UsersData.json";

        public UserList GetAllUsers()
        {
            WebClient client = new WebClient();

            string usersInfoAsString = client.DownloadString("https://fakestoreapi.com/users");

            List<UserDataEntity>? resultFromUrlAsDataEntitie = JsonConvert.DeserializeObject<List<UserDataEntity>>(usersInfoAsString);

            UserList userInfoList = new UserList
            {
                usersList = resultFromUrlAsDataEntitie.Select(userDataEntitie => new User
                {
                    Id = userDataEntitie.id,
                    City = userDataEntitie.address.city,
                    Email = userDataEntitie.email,
                    UserName = userDataEntitie.username,
                    Password = userDataEntitie.password,
                    FirstName = userDataEntitie.name.firstname,
                    LastName = userDataEntitie.name.lastname
                }).ToList(),
            };
            return userInfoList;
        }

        public bool SaveUsersInFile(string list)
        {

            _localDbRelPath = new StreamWriter(_routeFile);

            _localDbRelPath.WriteLine(list);

            _localDbRelPath.Close();

            return true;
        }
    }
}
