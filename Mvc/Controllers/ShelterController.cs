using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;
using System.Collections.Generic;
using System.Net;

namespace Mvc.Controllers
{
    [ApiController]
    public class ShelterController : ApiControllerAttribute
    {
        Shelters[] Shelter = new Shelters[]
        {
            new Shelters { Id = 1, Name = "Dierenbescherming Mechelen", Owner ="Kurt Olbrechts"},
            new Shelters { Id = 2, Name = "Dierenopvangcentrum Zemst", Owner="Liesbet Van Hemelrijk"},

        };
        private readonly ILogger<ShelterController> _logger;

        public ShelterController(ILogger<ShelterController> logger)
        {
            _logger = logger;
        }

        // GET: api/Shelter/1
        [HttpGet("{id}")]
        public IEnumerable<Shelters> GetAllShelters()
        {
            return Shelter;
        }
    }
}
