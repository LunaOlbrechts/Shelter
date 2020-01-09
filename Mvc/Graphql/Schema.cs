using GraphQL.Types;
using GraphQL;
using Api.Database;

namespace Mvc.Graphql 
{
  public class MySchema 
  {
    private ISchema _schema { get; set; }
    public ISchema GraphQLSchema 
    {  
      get 
      {
        return this._schema;
      }
    }

    public MySchema() 
    {
      this._schema = Schema.For(@"
          type Animal {
            id: ID
            name: String,
          }

          type Shelter {
            id: ID,
            name: String,
          }

          type Query {
              animals: [Animal]
              shelters: [Shelter]
          }
      ", _ =>
      {
        _.Types.Include<Query>();
      });
    }

  }
}