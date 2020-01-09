using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Shelter.Shared;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Http;
using System.Web;

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
            return Ok(shelter);
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
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            var shelter = _dataAccess.GetShelterById(shelterId);

            if (animal == null || shelter == null)
            {
                return NotFound("404 shelter or/and animal are not found");
            }

            return Ok(animal);
        }

        [HttpDelete("{shelterId}/animals/{animalId}")]
        public IActionResult DeleteAnimal(int animalId, int shelterId)
        {
            var shelter = _dataAccess.GetShelterById(shelterId);
            var animal = _dataAccess.GetAnimalByShelterAndId(animalId, shelterId);

            if (shelter == null || animal == null)
            {
                return NotFound("404 animal and/ or schelter are not found");
            }

            _dataAccess.DeleteAnimal(animalId, shelterId);
            return Ok(shelter);
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

            _dataAccess.UpdateAnimal(animal, HttpContext.Request.Form);
            return Ok(animal);
        }

        [HttpPost("{shelterId}/animals")]
        public IActionResult CreateAnimal(int shelterId)
        {
            var form = HttpContext.Request.Form;
            var shelter = _dataAccess.GetShelterById(shelterId);

            if (shelter == null)
            {
                return NotFound("404 shelter is not found");
            }
            if ((string)form["Name"] == null)
            {
                return StatusCode(422);
            }

            var newAnimal = _dataAccess.CreateAnimal(shelterId, HttpContext.Request.Form);
            return Ok(newAnimal);
        }
    }
}