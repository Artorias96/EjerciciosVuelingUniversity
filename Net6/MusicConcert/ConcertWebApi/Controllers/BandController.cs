using Business.ServiceContracts;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ConcertWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly ICrowdSelectedService _crowdSelectedService;

        public BandController(ICrowdSelectedService crowdSelectedService)
        {
            _crowdSelectedService = crowdSelectedService; 
        }
        /// <summary>
        /// Combination of musicians for selected Date
        /// </summary>
        /// <param name="dayOfMeeting"> Date of meeting Input format: yyy-MM-dd (example: 2023/06/30)</param>
        /// <response code="200">list of potential musicians for the selected Date </response> 
        [HttpGet]
        public IActionResult SelectCrowdForMeeting([Required] DateTime dayOfMeeting)
        {
            List<SelectedMusicianDTO> result = new();
            try
            {
                result = _crowdSelectedService.SelectCrowdForMeeting(dayOfMeeting);
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(result);
        }
    }
}
