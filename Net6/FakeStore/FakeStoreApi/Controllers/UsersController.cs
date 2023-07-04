using Business.Dtos;
using Business.ServiceContracts;
using Business.ServiceImplementations;
using Domain.DomainEntities.ProductEntities;
using Domain.DomainEntities.UserEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        private const string errorMsg = "Error trying to search data";
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        /// <summary>
        /// Method to get All Users From Api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDefaultListUsers")]
        public IActionResult ShowAllProducts()
        {
            try
            {
                UserList usersInfo = _userService.GetAllUsers();
                _logger.LogInformation("The information has been read successfully");

                return Ok(usersInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMsg);
                return BadRequest($"Some error ocurred {ex.Message}");
            }
        }
    }
}
