using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Shelter.Shared
{
    public interface IDatabaseInitializer
    {
        void Initialize();
    }
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private ShelterContext _context;
        private ILogger<DatabaseInitializer> _logger;
        public DatabaseInitializer(ShelterContext context, ILogger<DatabaseInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Initialize()
        {
            try
            {
                if (_context.Database.EnsureCreated())
                {
                    AddData();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error occurred while creating database");

            }
        }
        private void AddData()
        {
            var Shelter = new Shelters()
            {
                Name = "Dierenbescherming Mechelen",
                Owner = new Person()
                {
                    FirstName = "Kurt",
                    LastName = "Olbrechts"
                },
                Animals = new List<Animal> {
                    new Dog() { Name = "Koda", DateOfBirth = "11-02-2017", IsChecked = true, KidFriendly = true, Since = "02-09-2019", Race = "Husky", Barker = false, Id=1},
                    new Dog() { Name = "Beatle", DateOfBirth = "06-10-2012", IsChecked = false, KidFriendly = true, Since = "15-10-2018", Race = "Beatle", Barker = true, Id=2},
                    new Dog() { Name = "Bahia", DateOfBirth = "14-09-2015", IsChecked = true, KidFriendly = true, Since = "07-03-2019", Race = "Dalmatian", Barker = false, Id=3},
                    new Cat() {Name = "Max", DateOfBirth = "29-06-2018", IsChecked = false, KidFriendly = false, Since = "16-10-2019", Race = "Seamese", Declawed = true, Id = 4},
                    new OtherAnimal() {Name = "Flappie", DateOfBirth = "03-04-2019", IsChecked = true, KidFriendly = true, Since = "28-07-2019", Race = "Vlaamse Reus", Description = "blablabla", Kind = "Rabbit", Id = 5}
         }
            };
            _context.Shelters.Add(Shelter);
            _context.SaveChanges();
        }
    }
}