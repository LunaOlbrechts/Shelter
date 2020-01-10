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
                type Animal{
                    name: String
                }

                type Query{
                  hello: String
                  animals: [Animal]
                }
                ", _ =>
            {
                _.Types.Include<Query>();
            });
        }
    }
}