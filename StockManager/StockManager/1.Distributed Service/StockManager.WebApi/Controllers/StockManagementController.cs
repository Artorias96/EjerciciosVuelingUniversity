using Business.CustomExceptions;
using Business.ServiceContracts;
using Domain.EntitiesDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using StockManager.WebApi.Helpers;
using StockManager.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace StockManager.WebApi.Controllers
{
    public class StockManagementController : ApiController
    {
        private readonly IStockManagementService _service;

        public StockManagementController(IStockManagementService service)
        {
            _service = service;
        }
        // GET: StockManager
        [HttpPost]
        public IHttpActionResult Register(StockManagementModel stockModel)
        {
            var entity = new StockEntityDomain
            {
                StockId = stockModel.StockId,
                StockName = stockModel.StockName,
                StockDescription = stockModel.StockDescription,
            };

            try
            {
                string msg = _service.Register(entity);

                return Ok(msg);
            }
            catch (OutOfRangeExceptions ex)
            {

                return BadRequest(ex.Message);
            }
            catch (WrongFormatException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }
    }
}