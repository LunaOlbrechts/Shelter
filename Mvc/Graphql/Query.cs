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
using Microsoft.AspNetCore.Http;


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
            using(var _context= new ShelterContext()){
                 return _context.Shelters.ToList();
            }
        }

        [GraphQLMetadata("animals")]
        public IEnumerable<Animal> GetAnimals()
        {
            using(var _context= new ShelterContext()){
                 return _context.Animals.ToList();
            }
        }
    }
}