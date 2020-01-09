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

    [GraphQLMetadata("animals")]
    public IEnumerable<Animal> GetAnimals()
    {
      return Enumerable.Empty<Books>();
    }

    [GraphQLMetadata("shelters")]
    public IEnumerable<Shelters> GetShelters() 
    {
      return Enumerable.Empty<Authors>();
    }

    [GraphQLMetadata("author")]
    public Author GetAuthor(int id)
    {
      return null;
    }
  }
}