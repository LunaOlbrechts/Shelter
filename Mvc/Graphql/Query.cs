using System.Collections.Generic;
using GraphQL;
using System.Linq;
using Api.Database;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shelter.Shared;


namespace Mvc.Graphql
{
    public class Query
    {

        [GraphQLMetadata("shelters")]
        public IActionResult GetAllShelters()
        {
            return Ok(_dataAccess.GetAllShelters());
        }

        [GraphQLMetadata("sheltersFull")]
        public IActionResult GetAllSheltersFull()
        {
            // You return a list here, "not found" is not an issue -- an empty list is still a valid list.
            return Ok(_dataAccess.GetAllSheltersFull());
        }

        [GraphQLMetadata("idShelter")]
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

        [GraphQLMetadata("animals")]
        public IActionResult GetShelterAnimals(int id)
        {
            // if you don't find the shelter, return a 404. Again, an empty list is an empty list so empty list of animal is a valid result.
            var animals = _dataAccess.GetAnimals(id);
            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound("404 the Shelter is not found") : Ok(animals);
        }

         [GraphQLMetadata("animal")]
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
    }
}