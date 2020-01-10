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
using Shelter.Shared;

namespace Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var schema = Schema.For(@"
                type Query {
                 hello: String
                }
            ");
            var root = new { Hello = "Hello World!" };
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
