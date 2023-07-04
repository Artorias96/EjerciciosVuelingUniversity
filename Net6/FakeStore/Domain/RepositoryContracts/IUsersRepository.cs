using Domain.DomainEntities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryContracts
{
    public interface IUsersRepository
    {
        UserList GetAllUsers();
        bool SaveUsersInFile(string list);
    }
}
