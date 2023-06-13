using Domain.CustomExceptions;
using Domain.Entities;
using Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace WebApi.Controllers
{
    public class CarColorController : ApiController
    {

        private readonly ICarColorService _Service;

        public CarColorController(ICarColorService service)
        {
            _Service = service;
        }
        // GET: CarColor

        /// <summary>
        /// This method add the information in the txt repository
        /// </summary>
        /// <param name="carSpecifications"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Register(CarColorModel carSpecifications)
        {

            if (carSpecifications.colorInfo.Count != 3)
            {
                return BadRequest("Only 3 coordinates allowed");
            }

            var entity = new CarColor
            {
                colorCar = carSpecifications.colorInfo[0], 
                percentage = Int32.Parse(carSpecifications.colorInfo[1]),
                marca = carSpecifications.colorInfo[2]
            };

            try
            {
                _Service.Register(entity);
            }
            catch (InvalidColorException ex)
            {
                return BadRequest($"Some problem found on Color {ex.Message}, select a color Red, Blue or Green");
            }
            catch (InvalidIntException ex)
            {
                return BadRequest($"Some problem found on percentage {ex.Message},numbers need to be between 0 and 100 but can´t be 0");
            }
            catch (Exception ex)
            {
                return BadRequest($"Some error ocurred {ex.Message}");
            }

            return Ok("Data introduced succesfully");

        }
    }
}