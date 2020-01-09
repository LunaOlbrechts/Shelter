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
            return Enumerable.Empty<Shelters>();
        }

        [GraphQLMetadata("sheltersFull")]
        public IEnumerable<Shelter.Shared.Shelters> GetAllSheltersFull()
        {
            // You return a list here, "not found" is not an issue -- an empty list is still a valid list.
            return Enumerable.Empty<Shelters>();
        }

        [GraphQLMetadata("idShelter")]
        public Shelter.Shared.Shelters GetShelter(int id)
        {
            return null;
        }

        [GraphQLMetadata("animals")]
        public IEnumerable<Animal> GetShelterAnimals(int id)
        {
            return null;
        }

        [GraphQLMetadata("animal")]
        public IEnumerable<Animal> GetAnimalDetails(int shelterId, int animalId)
        {
            return null;
        }
    }
}