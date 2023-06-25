using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace TestInMemoryCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InMemoryCacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        public InMemoryCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<List<User>> GetUsersCacheAsync()
        {
            List<User>? output = _memoryCache.Get<List<User>>("users");

            if (output is not null) return output;

            output = new()
            {               
            new() { FirstName = "Tim", LastName = "Corey" },
            new() { FirstName = "Sue", LastName = "Storm" },
            new() { FirstName = "Jane", LastName = "Jones" }
            };
            List<User> output2 = new()
            {
            new() { FirstName = "Tim2", LastName = "Corey2" },
            new() { FirstName = "Sue2", LastName = "Storm2" },
            new() { FirstName = "Jane2", LastName = "Jones2" }
            };

             await Task.Delay(10);

            var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)).SetSlidingExpiration(TimeSpan.FromSeconds(20));

            _memoryCache.Set("users", output, cacheOptions);
            _memoryCache.Set("users", output2, cacheOptions);

            return output;
        }

        //public MemoryCache Cache { get; } = new MemoryCache(
        //new MemoryCacheOptions
        //{
        //    SizeLimit = 1024
        //});

        public class User
        {
            public string? FirstName { get; set;}
            public string? LastName { get; set;} 
        }
    }
}
