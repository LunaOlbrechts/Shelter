using Shelter.Shared;
using GraphQL;

namespace Mvc
{
    [GraphQLMetadata("Mutation")]
    public class Mutation
    {
        /*[GraphQLMetadata("addAnimal")]
        public Author Add(string name)
        {
            using (var db = new StoreContext())
            {
                var author = new Author() { Name = name };
                db.Authors.Add(author);
                db.SaveChanges();
                return author;
            }
        }*/
    }
}