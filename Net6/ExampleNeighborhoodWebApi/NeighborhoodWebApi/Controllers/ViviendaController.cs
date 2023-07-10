using DomainContracts.DomainEntities;
using DomainContracts.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NeighborhoodWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViviendaController : ControllerBase
    {
        private readonly IViviendasService _viviendasService;
        private readonly ILogger<ViviendaController> _logger;

        public ViviendaController(IViviendasService viviendasService, ILogger<ViviendaController> logger)
        {
            _viviendasService = viviendasService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllConversions([Required] int id)
        {
            PrecioCasa precioTotal = await _viviendasService.GetViviendaById(id);

            if (precioTotal == null)
            {
                _logger.LogError("ERROR, vivienda buscada por Id retorno null");
                return BadRequest("La vivienda buscada por ID no existe");
            }

            return Ok(precioTotal);
        }
    }
}
