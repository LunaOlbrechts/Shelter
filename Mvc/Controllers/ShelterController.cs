using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    [ApiController]
    [Route("/api/shelters")]
    public class ShelterController : Controller
    {
        private readonly ILogger<ShelterController> _logger;
        private readonly IShelterDataAccess _dataAccess;
        public ShelterController(ILogger<ShelterController> logger, IShelterDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }
        [Route("")]
        public IActionResult GetAllShelters()
        {
            return Ok(_dataAccess.Shelters);
        }
    }
}
