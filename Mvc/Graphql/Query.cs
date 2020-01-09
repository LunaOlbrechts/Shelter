using System.Collections.Generic;
using GraphQL;
using System.Linq;
using Api.Database;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Graphql 
{
  public class Query
  {

    [GraphQLMetadata("books")]
    public IEnumerable<Book> GetBooks()
    {
      return Enumerable.Empty<Books>();
    }

    [GraphQLMetadata("authors")]
    public IEnumerable<Author> GetAuthors() 
    {
      return Enumerable.Empty<Authors>();
    }

    [GraphQLMetadata("author")]
    public Author GetAuthor(int id)
    {
      return null;
    }

    [GraphQLMetadata("hello")]
    public string GetHello()
    {
      return "World";
    }
  }
}