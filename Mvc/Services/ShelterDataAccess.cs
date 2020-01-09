using System.Collections.Generic;
using System.Linq;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Mvc
{
    public interface IShelterDataAccess
    {
        IEnumerable<Shelter.Shared.Shelters> GetAllShelters();
        IEnumerable<Shelter.Shared.Shelters> GetAllSheltersFull();
        Shelter.Shared.Shelters GetShelterById(int id);
        IEnumerable<Animal> GetAnimals(int animalId);
        Animal GetAnimalByShelterAndId(int shelterId, int animalId);
        void DeleteAnimal(int animalId, int shelterId);
        void UpdateAnimal(Animal animal, IFormCollection form);
        Animal CreateAnimal(int shelterId, IFormCollection form);
    }
    public class ShelterDataAccess : IShelterDataAccess
    {
        private ShelterContext _context;
        public ShelterDataAccess(ShelterContext context)
        {
            _context = context;
        }
        public IEnumerable<Shelter.Shared.Shelters> GetAllShelters()
        {
            return _context.Shelters;
        }
        public IEnumerable<Shelter.Shared.Shelters> GetAllSheltersFull()
        {
            return _context.Shelters
              .Include(Shelter => Shelter.Animals)
              .Include(Shelter => Shelter.Owner);
        }
        public Animal GetAnimalByShelterAndId(int shelterId, int animalId)
        {
            return _context.Animals
              .FirstOrDefault(x => x.SheltersId == shelterId && x.Id == animalId);
        }
        public IEnumerable<Animal> GetAnimals(int shelterId)
        {
            return _context.Shelters
              .Include(Shelter => Shelter.Animals)
              .FirstOrDefault(x => x.Id == shelterId)?.Animals;
        }
        public Shelter.Shared.Shelters GetShelterById(int id)
        {
            return _context.Shelters.FirstOrDefault(x => x.Id == id);
        }
        public void DeleteAnimal(int animalId, int shelterId)
        {
            var data = _context.Shelters
                .Include(Shelter => Shelter.Animals)
                .FirstOrDefault(x => x.Id == shelterId)?.Animals;
            Animal animal = _context.Animals.Find(animalId);
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }
        public void UpdateAnimal(Animal animal, IFormCollection form)
        {
            animal.Name = form["name"];
            animal.Race = form["race"];
            animal.KidFriendly = form["kid_friendly"] == "true";
            _context.SaveChanges();
        }
        public Animal CreateAnimal(int shelterId, IFormCollection form)
        {
            var newAnimal = new Animal();
            newAnimal.Name = form["name"];
            newAnimal.Race = form["race"];
            newAnimal.KidFriendly = form["kid_friendly"] == "true";
            newAnimal.SheltersId = shelterId;
            _context.Add(newAnimal);
            _context.SaveChanges();
            return newAnimal;
        }
    }
}