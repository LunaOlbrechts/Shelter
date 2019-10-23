using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;

namespace Mvc.Controllers
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

        public IActionResult Detail(int id)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Animal))
            {
                return NotFound();
            }
            return View(targetAnimal);
        }
        public IActionResult Delete(int id)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Animal))
            {
                return NotFound();
            }
            return View(targetAnimal);
        }

        [HttpPost]
        public IActionResult DoDelete(int id)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Animal))
            {
                return NotFound();
            }
            ShelterDatabase.Shelter.Animals.Remove(targetAnimal);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int id)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Animal))
            {
                return NotFound();
            }
            return View(targetAnimal);
        }
    }
}
