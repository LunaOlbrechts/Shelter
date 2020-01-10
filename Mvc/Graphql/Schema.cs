using GraphQL.Types;
using GraphQL;
using Shelter.Shared;

namespace Mvc
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
                type Shelters {
                    Id: int
                    Name: String
                    animals: [Animals]
                }
                type Animals{
                    Id: int
                    Name: String
                }
        
                type Query{
                    shelter(Id: int!): Shelters
                    animal(Id: int!): Animals
                    hello: String
                }
                ", _ =>
            {
                _.Types.Include<Query>();
            });
        }
    }
}