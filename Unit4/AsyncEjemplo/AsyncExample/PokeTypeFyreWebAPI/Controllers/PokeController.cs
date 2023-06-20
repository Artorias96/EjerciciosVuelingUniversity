using Business.ServiceContracts;
using Business.ServiceImplementations;
using Domain.DomainEntities;
using Infrastructure.Dtos;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ILogger = Serilog.ILogger;

namespace PokeTypeFyreWebAPI.Controllers
{
    public class PokeController : ApiController
    {
        private readonly IPokeService _pokeService;
        private readonly ILogger _logger; 
        public PokeController(IPokeService pokeFyreService, ILogger logger)
        {
            _pokeService = pokeFyreService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetTypeFyreMoves")]
        public async Task<IHttpActionResult> FirstAttacksTypeFyre()
        {
            List<string> typeFyreMovesNames = await _pokeService.GetMovesTypeFyreInfoInSpanish();

            return Ok(typeFyreMovesNames);
        }

        [HttpGet]
        [Route("GetTypeFyrePokes")]
        public async Task<IHttpActionResult> FirstPokeNamesTypeFyre()
        {
            List<string> typeFyrePokeNames = await _pokeService.GetPokeNames();

            _logger.Information("The information has been read with successfully");
            return Ok(typeFyrePokeNames);
        }

        [HttpPost]
        [Route("GetSelectedTypeMoves")]
        public async Task<IHttpActionResult> GetSelectedType(string str)
        {
            try
            {


                PokeTypeInfo typeSelectedInfo = await _pokeService.GetMovesAndPokesSelectedTypeInSpanish(str);
                _logger.Information("The information has been introduced with successfully");
                return Ok(typeSelectedInfo);


            }catch (Exception ex)
            {
                _logger.Error("Error here");
                return BadRequest("Error juanito");

            }
        }
    }
}
