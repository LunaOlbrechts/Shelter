using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;

namespace Mvc.Controllers
{
    [ApiController]
    public class ShelterController : ControllerBase
    {

        private readonly ILogger<ShelterController> _logger;

        public ShelterController(ILogger<ShelterController> logger)
        {
            _logger = logger;
        }

        // GET: api/Shelter/1
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
