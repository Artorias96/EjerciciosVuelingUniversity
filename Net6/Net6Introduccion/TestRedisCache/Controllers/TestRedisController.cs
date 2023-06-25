using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestRedisCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRedisController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        public TestRedisController(IDistributedCache cache)
        {
            _distributedCache = cache;
        }

        [HttpGet]
        public IActionResult test()
        {
            string ? dataFromCacheAsString = _distributedCache.GetString("users");

            if (dataFromCacheAsString != null)
            {
                List<User>? dataFromCache = JsonSerializer.Deserialize<List<User>>(dataFromCacheAsString);

                return Ok(dataFromCache);
            }
            else
            {
                List<User> dataStoreInCache = new()
            {
            new() { FirstName = "Tim", LastName = "Corey" },
            new() { FirstName = "Sue", LastName = "Storm" },
            new() { FirstName = "Jane", LastName = "Jones" }
            };
                string dataStoreInCacheAsString = JsonSerializer.Serialize(dataStoreInCache);

                DistributedCacheEntryOptions distributedCacheEntryOptions = new()
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow,
                };

                _distributedCache.SetString("users", dataStoreInCacheAsString);
            }
            return BadRequest();
        }
        public class User
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
        }
    }
}
