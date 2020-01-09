using System.Collections.Generic;
using GraphQL;
using System.Linq;
using Shelter.Shared;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Mvc.Graphql
{
    public class Query
    {

        [GraphQLMetadata("animals")]
        public IEnumerable<Animal> GetAnimals()
        {
            return Enumerable.Empty<Animal>();
        }

        [GraphQLMetadata("shelters")]
        public IEnumerable<Shelters> GetShelters()
        {
            return Enumerable.Empty<Shelters>();
            // return StarWarsDB.GetJedis();

        }

        [GraphQLMetadata("author")]
        public Person GetPerson(int id)
        {
            return null;
        }
    }
}