using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;

namespace Shelter.Mvc.Controllers
{
    public class ShelterController : Controller
    {
        private readonly ILogger<ShelterController> _logger;

        public ShelterController(ILogger<ShelterController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(ShelterDatabase.Shelter);
        }
    }
}
