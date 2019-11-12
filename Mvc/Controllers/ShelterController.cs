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

        // GET api
        [HttpGet("{Animals/id}")]
        public string Get(int id)
        {
            return "value";
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
        public IActionResult DoEdit(int id, string name)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Animal))
            {
                return NotFound();
            }
            targetAnimal.Name = name;
            return RedirectToAction(nameof(Index));

        }
    }
}
