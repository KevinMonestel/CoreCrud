using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
