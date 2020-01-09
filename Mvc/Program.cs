using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphQL;
using GraphQL.Types;

namespace Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //Declaring the schema. 
            var schema = Schema.For(@"
            type Query {
                hello: String
            }
            ");
            // Resolving the query. It maps something inside the query. If the user asks for Hello, the answer will be "Hello world".
            var root = new { Hello = "Hello World!" };
            // Executing the query
            var json = schema.Execute(_ =>
            {
                _.Query = "{ hello }";
                _.Root = root;
            });
            Console.WriteLine(json);
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}