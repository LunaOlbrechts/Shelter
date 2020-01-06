using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
            // find shelter in database if the shelter does not excist trow 404 Not found
            var shelter = _dataAccess.GetShelterById(id);

            if (shelter == null)
            {
                return NotFound("404 shelter is not found");
            }
            else
            {
                return Ok(shelter);
            }

        }
        [HttpGet("{id}/animals")]
        public IActionResult GetShelterAnimals(int id)
        {
            // if you don't find the shelter, return a 404. Again, an empty list is an empty list so empty list of animal is a valid result.
            var animals = _dataAccess.GetAnimals(id);
            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound("404 the Shelter is not found") : Ok(animals);
        }
        [HttpGet("{shelterId}/animals/{animalId}")]
        public IActionResult GetAnimalDetails(int shelterId, int animalId)
        {
            // this can return two kinds of 404's; one for the non-existing shelter and one for the non-existing animal.
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            var shelter = _dataAccess.GetShelterById(shelterId);
            if (animal == null || shelter == null)
            {
                return NotFound("404 shelter or/and animal are not found");
            }
            else
            {
                return Ok(animal);
            }
        }
        [HttpDelete("{shelterId}/animals/{animalId}")]
        public IActionResult DeleteAnimal(int animalId, int shelterId)
        {
            _dataAccess.DeleteAnimal(animalId, shelterId);

            return RedirectToAction("GetAllSheltersFull");
        }

        [HttpPut("{shelterId}/animals/{animalId}")]
        public IActionResult UpdateAnimal(int animalId, int shelterId)
        {
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            var shelter = _dataAccess.GetShelterById(shelterId);

            if (animal == null || shelter == null)
            {
                return NotFound("404 shelter or/and animal are not found");
            }
            else
            {
                _dataAccess.UpdateAnimal(animal, HttpContext.Request.Form);
                return Ok(animal);
            }
        }

        [HttpPost("{shelterId}/animals/{animalId}")]
        public IActionResult CreateAnimal(int shelterId, int animalId)
        {
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            var shelter = _dataAccess.GetShelterById(shelterId);
            if (shelter == null)
            {
                return NotFound("404 shelter is not found");
            }
            else
            {
                _dataAccess.UpdateAnimal(animal, HttpContext.Request.Form);
                return Ok(animal);
            }
        }
    }
}