using Microsoft.EntityFrameworkCore;

namespace Shelter.Shared
{
    public class ShelterContext : DbContext
    {
        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Shelters> Shelters { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}