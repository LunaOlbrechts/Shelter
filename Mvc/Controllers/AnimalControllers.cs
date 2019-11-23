using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;

namespace Mvc.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;
        public AnimalController(ILogger<AnimalController> logger)
        {
            _logger = logger;
        }
       /*  public IActionResult Index()
        {
            return View(ShelterDatabase.Shelter);
        }
        public IActionResult Detail(int id)
        {
            //aparte classe maken om info uit database op te halen (Factory)
            //Graphql kunnen aan en uitzetten zonder programma crasht!! 
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
        } */
    } 
}
