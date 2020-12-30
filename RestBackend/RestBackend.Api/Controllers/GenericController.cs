using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestBackend.Api.Resources;

namespace RestBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        [HttpGet("date")]
        public ActionResult<string> GetDate()
        {
            var colTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime colTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, colTimeZone);

            return Ok($"{colTime:dd-MM-yyyy}");
        }

        [HttpPost("divide")]
        public ActionResult<decimal> Division([FromBody] DivisionResource divisionResource)
        {
            if (divisionResource.Dividend < divisionResource.Divider)
                return BadRequest("Invalid division");

            return Ok(divisionResource.Dividend / divisionResource.Divider);
        }
    }
}
