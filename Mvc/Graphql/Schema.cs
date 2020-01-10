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
                type Shelter {
                    id: ID,
                    name: String
                }

                type Animal{
                    id: ID,
                    name: String
                }
          
                type Query{
                    shelters: [Shelter]
                    animals: [Animal]
                    hello: String
                }
                ", _ =>
            {
                _.Types.Include<Query>();
            });
        }
    }
}