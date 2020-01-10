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
                    name: String,
                    adress: String,
                    animals: [Animal]
                }
                type Animal{
                    id: ID,
                    name: String,
                    race: String,
                    sheltersId: ID,
                    kidFriendly: String
                }
                type Query{
                    shelters: [Shelter]
                    animal(id: ID): Animal,
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