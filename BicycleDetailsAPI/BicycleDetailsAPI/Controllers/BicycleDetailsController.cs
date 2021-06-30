using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LowerLayer;
using BLL;
using Microsoft.Extensions.Logging;

namespace BicycleDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleDetailsController : ControllerBase
    {
        private readonly ILogger logger;
        private DetailsServices services;
        public BicycleDetailsController(ILogger<BicycleDetailsController> logger)
        {
            services = new DetailsServices();
            this.logger = logger;
        }
        [HttpGet]
        public IEnumerable<BicycleDetail> GetDetails([FromQuery] PageSettings page)
        {
            return services.GetDetailsList(page);
        }
        [HttpGet("{id}")]
        public BicycleDetail GetDetail(int id)
        {
            BicycleDetail detail = services.GetDetail(id);
            if (detail == null)
            {
                return null;
            }
            else
            {
                return detail;
            }
        }
        [HttpPost]
        public ActionResult AddDetail(BicycleDetail detail)
        {
            if (ModelState.IsValid)
            {
                string responce = services.AddEntity(detail);
                LogResponce(responce);
                return Ok(responce);
            }
            return Conflict();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDetail(int id)
        {
            return Ok(services.DeleteEntity(id));
        }
        [HttpPut]
        public ActionResult UpdateDetail(BicycleDetail detail)
        {
            if(ModelState.IsValid)
            {
                string responce = services.UpdateEntity(detail);
                LogResponce(responce);
                return Ok(responce);
            }
            return Conflict();
        }
        [HttpGet("{type}/typecolors")]
        public ActionResult GetDetailColors(string type)
        {
            
            return Ok(services.GetColors(type));
        }
        [HttpGet("{color}/coloredtypes")]
        public ActionResult GetColoredDetails(string color)
        {
            return Ok(services.GetTypes(color));
        }
        private void LogResponce(string responce)
        {
            logger.LogInformation($"{DateTime.Now} {responce}");
        }
    }
}
