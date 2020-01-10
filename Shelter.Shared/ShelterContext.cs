using Microsoft.EntityFrameworkCore;

namespace Shelter.Shared
{
    public class ShelterContext : DbContext
    {
        public ShelterContext() { }
        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Shelter.db");
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Shelters> Shelters { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}