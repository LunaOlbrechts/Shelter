using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;

namespace Mvc.Controllers
{
    [Route("/api/animals")]
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;
        public AnimalController(ILogger<AnimalController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
