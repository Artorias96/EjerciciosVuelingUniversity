using Business.ServiceImplementations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DefaultController : ApiController
    {
        [Route("Test")]
        public IHttpActionResult test()
        {
            return Ok("test");
        }

        [HttpGet]
        [Route("GetDittoInfo")]
        public async Task<IHttpActionResult> Init()
        {
           DittoModel message = await new CommonService().ServiceMethod();

            return Ok(message);
        }

        public async Task<IHttpActionResult> Init(int id)
        {
            DittoModel message = await new CommonService().ServiceMethod();

            return Ok(message);
        }

        [Route("DittoNames")]
        public async Task<IHttpActionResult> SelectDitto()
        {
            List<DittoModel> dittoModelList = new List<DittoModel>()
            {
                new DittoModel()
                {
                base_experience = 1,
                height = 8,
                name = "DittoDePrueba",
                },
                new DittoModel()
                {
                base_experience = 5,
                height = 10,
                name = "OtroDitto",
                }
            };

           List<string> DittoNames = dittoModelList.Select(pokeinfo => pokeinfo.name).ToList();
           var DittoNamesComplesType = dittoModelList.Select(pokeinfo => new {pokeinfo.name, pokeinfo.height}).ToList();

            return Ok(DittoNamesComplesType);
        }

        [Route("DictionariIds")]
        public async Task<IHttpActionResult> GetDicctionaryIds()
        {
            Dictionary<string, IntsDicctionary> dic = new Dictionary<string, IntsDicctionary>
            {
                {"UNO", new IntsDicctionary{IdProperty = 1, IdPropertyList = new List<int> {1,2,3,4,5}} },
                {"DOS", new IntsDicctionary{IdProperty = 2, IdPropertyList = new List<int> {6,7,8,9,10}} },
                {"TRES", new IntsDicctionary{IdProperty = 3, IdPropertyList = new List<int> {11,12,13,14,15}} }
            };

            string dicAsString = JsonConvert.SerializeObject(dic);
            
            return Ok(dic);
        }
    }
}
