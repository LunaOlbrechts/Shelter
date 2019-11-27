using System.Collections.Generic;
using System.Linq;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mvc
{
    public interface IShelterDataAccess
    {
        IEnumerable<Shelter.Shared.Shelters> GetAllShelters();
        IEnumerable<Shelter.Shared.Shelters> GetAllSheltersFull();
        Shelter.Shared.Shelters GetShelterById(int id);
        IEnumerable<Animal> GetAnimals(int animalId);
        Animal GetAnimalByShelterAndId(int shelterId, int animalId);
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
    }
}