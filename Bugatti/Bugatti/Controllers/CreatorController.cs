using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bugatti.Controllers
{
    [Route("api/v1/creators")]
    public class CreatorController : Controller
    {
        [Route("test")]
        [HttpGet]
        public string Test()
        {
            return "creator controller";
        }
    }
}