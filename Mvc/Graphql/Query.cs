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

        [GraphQLMetadata("hello")]
        public string GetHello()
        {
            return "Hello Query class";
        }

        [GraphQLMetadata("shelters")]
        public IEnumerable<Shelter.Shared.Shelters> GetShelters()
        {
            using (var db = new Shelter.Shared.ShelterContext())
            {
                return null;
            }
        }

        [GraphQLMetadata("animals")]
        public IEnumerable<Shelter.Shared.Animal> GetAnimals()
        {
            using (var db = new Shelter.Shared.ShelterContext())
            {
                return null;
            }
        }


    }
}