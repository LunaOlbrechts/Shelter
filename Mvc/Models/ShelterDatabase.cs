using System.Collections.Generic;
using Shelter.Shared;

namespace Shelter.MVC.Models
{
  public class ShelterDatabase
  {
    private static bool _isInitialized = false;
    private static IEnumerable<Animal> _animals = null;
    private static Shelter.Shared.Shelter _shelter = null;

    private static void Initialize()
    {
      if (!_isInitialized)
      {
        var DierenbeschermingMechelen = new Shelter.Shared.Shelter()
        {
            Animals = new List<Animal> {
                new Dog() { Name = "Koda", DateOfBirth = "11-02-2017", IsChecked = true, KidFriendly = true, Since = "02-10-2019", Race = "Husky", Barker = false}
        }
        };

        _shelter = Shelter;
        _animals = Animals;
        _isInitialized = true;
      }
    }

    public static Shared.Shelter Shelter
    {
      get
      {
        Initialize();
        return _shelter;
      }
    }
    public static IEnumerable<Animal> Animals
    {
      get
      {
        Initialize();
        return _animals;
      }
    }

  }
}