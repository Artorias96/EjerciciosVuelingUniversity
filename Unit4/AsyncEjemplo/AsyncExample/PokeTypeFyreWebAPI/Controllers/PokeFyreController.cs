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
        
        [HttpGet]
        [Route("GetTypeFyreInfo")]
        public async Task<IHttpActionResult> FirstAttacksFyreType()
        {
            PokeFyre message = await new PokeFyreService().GetTypeFyreInfo();

            return Ok(message);
        }
    }
}
