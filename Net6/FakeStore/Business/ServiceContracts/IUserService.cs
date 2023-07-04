using Business.Dtos;
using Domain.DomainEntities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IUserService
    {
        UserList GetAllUsers();
    }
}
