using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;
using System.Collections.Generic;
using System.Net;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShelterController : ApiControllerAttribute
    {
        Shelters[] Shelter = new Shelters[]
        {
            new Shelters { Id = 1, Name = "Dierenbescherming Mechelen", Owner = new Person()
                {
                    FirstName = "Kurt",
                    LastName = "Olbrechts"
                }},
            new Shelters { Id = 2, Name = "Dierenopvangcentrum Zemst", Owner= new Person()
                {
                    FirstName = "Liesbet",
                    LastName = "Van Hemelrijk"
                }},
        };
        private readonly ILogger<ShelterController> _logger;
        public ShelterController(ILogger<ShelterController> logger)
        {
            _logger = logger;
        }
        // GET: api/Shelter/1
        public IEnumerable<Shelters> GetAllShelters()
        {
            return Shelter;
        }
    }
}
