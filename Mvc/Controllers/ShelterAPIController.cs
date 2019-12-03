using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    [Route("/api/shelters")]
    public class ShelterAPIController : Controller
    {
        private readonly IShelterDataAccess _dataAccess;
        private readonly ILogger<ShelterAPIController> _logger;
        public ShelterAPIController(ILogger<ShelterAPIController> logger, IShelterDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _logger = logger;
        }
        [HttpGet("/")]
        public IActionResult GetAllShelters()
        {
            return Ok(_dataAccess.GetAllShelters());
        }
        [HttpGet("full")]
        public IActionResult GetAllSheltersFull()
        {
            // You return a list here, "not found" is not an issue -- an empty list is still a valid list.
            return Ok(_dataAccess.GetAllSheltersFull());
        }
        [HttpGet("{id}")]
        public IActionResult GetShelter(int id)
        {
            // Either you find the shelter or not. If you don't find your resource return a 404 (as per https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html)
            var shelter = _dataAccess.GetShelterById(id); ;
            return shelter == default(Shelter.Shared.Shelters) ? (IActionResult)NotFound() : Ok(shelter);
        }
        [HttpGet("{id}/animals")]
        public IActionResult GetShelterAnimals(int id)
        {
            // if you don't find the shelter, return a 404. Again, an empty list is an empty list so empty list of animal is a valid result.
            var animals = _dataAccess.GetAnimals(id);

            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound() : Ok(animals);
        }
        [HttpGet("{shelterId}/animals/{animalId}")]
        public IActionResult GetAnimalDetails(int shelterId, int animalId)
        {
            // this can return two kinds of 404's; one for the non-existing shelter and one for the non-existing animal.
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            return animal == default(Shelter.Shared.Animal) ? (IActionResult)NotFound() : Ok(animal);
        }
        [HttpGet("animals/update")]
        public ActionResult<Animal> UpdateAnimal(int animalId, string name)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == animalId);
            if (targetAnimal == default(Animal))
            {
                return NotFound();
            }
            targetAnimal.Name = name;
            return RedirectToAction(nameof(GetShelterAnimals));
        }

        [HttpPost("{id}/animals")]
        public IActionResult DeleteAnimal(int animalId, int shelterId)
        {
            var animals = _dataAccess.DeleteAnimal(animalId, shelterId);
            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound() : Ok(animals);
        }
    }
}