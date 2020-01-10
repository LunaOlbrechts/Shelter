using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelter.Shared;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using Mvc;
using Newtonsoft.Json.Linq;
using System;

namespace Mvc.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphqlController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new MySchema();
            var inputs = query.Variables.ToInputs();
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema.GraphQLSchema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.ExposeExceptions = true;
                _.Inputs = inputs;
            });
            return Ok(result);
        }
    }
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}