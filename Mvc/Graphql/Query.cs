using System.Collections.Generic;
using GraphQL;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shelter.Shared;

namespace Mvc
{
    public class Query
    {
        [GraphQLMetadata("shelters")]
        public IEnumerable<Shelter.Shared.Shelters> GetAllShelters()
        {
            return Enumerable.Empty<Shelter.Shared.Shelters>();
        }
        [GraphQLMetadata("sheltersFull")]
        public IEnumerable<Shelter.Shared.Shelters> GetAllSheltersFull()
        {
            // You return a list here, "not found" is not an issue -- an empty list is still a valid list.
            return Enumerable.Empty<Shelter.Shared.Shelters>();
        }
        [GraphQLMetadata("idShelter")]
        public Shelter.Shared.Shelters GetShelter(int id)
        {
            return null;
        }
        [GraphQLMetadata("animals")]
        public IEnumerable<Shelter.Shared.Shelters> GetShelterAnimals()
        {
            return null;
        }
        [GraphQLMetadata("animalDetail")]
        public IEnumerable<Shelter.Shared.Animal> GetAnimalDetails(int shelterId, int animalId)
        {
            return null;
        }
        [GraphQLMetadata("hello")]
        public string GetHello()
        {
            return "Hello Query class";
        }
    }
}