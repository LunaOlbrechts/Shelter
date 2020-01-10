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


     
    }
}