using System.Collections.Generic;
using Shelter.Shared;

namespace Mvc.Models
{
    public class ShelterDatabase
    {
        private static bool _isInitialized = false;
        private static Shelter.Shared.Shelter _shelter = null;

        private static void Initialize()
        {
            if (!_isInitialized)
            {
                var DierenbeschermingMechelen = new Shelter.Shared.Shelter()
                {
                    Animals = new List<Animal> {
                      new Dog() { Name = "Koda", DateOfBirth = "11-02-2017", IsChecked = true, KidFriendly = true, Since = "02-09-2019", Race = "Husky", Barker = false, Id=1},
                      new Dog() { Name = "Beatle", DateOfBirth = "06-10-2012", IsChecked = false, KidFriendly = true, Since = "15-10-2018", Race = "Beatle", Barker = true, Id=2},
                      new Dog() { Name = "Bahia", DateOfBirth = "14-09-2015", IsChecked = true, KidFriendly = true, Since = "07-03-2019", Race = "Dalmatian", Barker = false, Id=3},
                    }
                };

                _shelter = DierenbeschermingMechelen;
                _isInitialized = true;
            }
        }

        public static Shelter.Shared.Shelter Shelter
        {
            get
            {
                Initialize();
                return _shelter;
            }
        }
    }
}