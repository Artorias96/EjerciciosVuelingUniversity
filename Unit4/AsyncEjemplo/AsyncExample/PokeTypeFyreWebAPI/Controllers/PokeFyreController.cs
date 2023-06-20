using Business.ServiceContracts;
using Business.ServiceImplementations;
using Domain.DomainEntities;
using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PokeTypeFyreWebAPI.Controllers
{
    public class PokeFyreController : ApiController
    {
        private readonly IPokeFyreService _pokeFyreService;

        public PokeFyreController(IPokeFyreService pokeFyreService)
        {
            _pokeFyreService = pokeFyreService;
        }

        [HttpGet]
        [Route("GetTypeFyreInfo")]
        public async Task<IHttpActionResult> FirstAttacksFyreType()
        {
            List<string> typeFyreNames = await _pokeFyreService.GetTypeFyreInfoInSpanish();

            return Ok(typeFyreNames);
        }
    }
}
