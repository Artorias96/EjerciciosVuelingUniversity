using Domain;
using Domain.CustomExceptions;
using Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SpatialCoordinates.WebAPI.Controllers
{
    public class CoordinatesController : ApiController
    {
        private readonly ICoordinatesService _service;
        public CoordinatesController(ICoordinatesService service)
        {
            _service = service;
        }
        /// <summary>
        /// Actions to manage coordinates
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Register(List<decimal> coordinates)
        {
            if (coordinates.Count != 3)
            {
                return BadRequest("Only 3 coordinates allowed");
            }
            Coordinates coords = new Coordinates
            {
                Coord1 = coordinates[0],
                Coord2 = coordinates[1],
                Coord3 = coordinates[2],
            };
            try
            {
                _service.Register(coords);
            }
            catch (InvalidCoord1Exception ex)
            {
                return BadRequest($"Some problem found on Coord1{ex.Message}");
            }
            catch (CannotSaveDataExceptions ex)
            {
                return BadRequest($"Some problem found trying to save data {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Some error ocurred {ex.Message}");
            }

            //return BadRequest("someting go wrong");
            return Ok("everything go ok");
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<string> result = _service.GetList();

            return Json(result);
        }
    }
}