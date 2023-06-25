using EntityFrameworkSQLApi.DbContextFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSQLApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlServerTestController : ControllerBase
    {

        public SqlServerTestController()
        {
            
        }

        public void Test()
        {
            DbContextOptions dbContextOptiones = new DbContextOptions();   

            TestSQLServerConnectionFromNet6Context dbConnection = new();
        }
    }
}
