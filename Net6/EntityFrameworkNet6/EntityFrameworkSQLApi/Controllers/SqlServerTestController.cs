using EntityFrameworkSQLApi.DbContextFolder;
using EntityFrameworkSQLApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSQLApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlServerTestController : ControllerBase
    {
        private readonly TestSQLServerConnectionFromNet6Context _dbContext;
        public SqlServerTestController(TestSQLServerConnectionFromNet6Context dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        public void Test()
        {
            _dbContext.Users.Add(new Users
            {
                Name = "Santiago",
                Surname = "Sanchez Costa",
                Workers = new Workers
                     {
                         YearsOfExperience = 7
                     }   
            });
            _dbContext.SaveChanges();
        }
    }
}
