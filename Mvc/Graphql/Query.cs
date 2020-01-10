using System.Collections.Generic;
using GraphQL;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shelter.Shared;
using System.Data;
using System.Net.Http;
using System.Web;

namespace Mvc
{
    public class Query
    {
        private readonly IShelterDataAccess _dataAccess;
        public Query(IShelterDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [GraphQLMetadata("hello")]
        public string GetHello()
        {
            return "Hello Query class";
        }

        [GraphQLMetadata("animal")]
        public IEnumerable<Shelter.Shared.Animal> GetAnimals(int animalId)
        {
            return _dataAccess.GetAnimals(animalId);
        }
    }
}