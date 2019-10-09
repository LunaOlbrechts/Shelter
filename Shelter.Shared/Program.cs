using System;
using System.Collections.Generic;
using System.Linq;



namespace Shelter.Shared
{
    class Program
    {
        static void Main(string[] args)
        {
            //make new object of shelter
            var DierenbeschermingMechelen = new Shelter() { Name = "Dierenbescherming Mechelen" };
            // make new object of person
            var Owner = new Person { FirstName = "Thomas", LastName = "Van Hemelrijk" };
            Console.WriteLine($"{Owner.FirstName} {Owner.LastName}");

            var Dog1 = new Dog() { Name = "Koda", DateOfBirth = "11-02-2017", IsChecked = true, KidFriendly = true, Since = "02-10-2019", Race = "Husky", Barker = false };

            DierenbeschermingMechelen.ShelterAnimals.Add(Dog1);
            // print list of animals
            DierenbeschermingMechelen.ShelterAnimals.ToList().ForEach(CurrentAnimal =>
            {
                Console.WriteLine($"{CurrentAnimal.Name} {CurrentAnimal.DateOfBirth} - Checked: {CurrentAnimal.IsChecked} - Kid friendly: {CurrentAnimal.KidFriendly} - In shelter since: {CurrentAnimal.Since}");

                if (CurrentAnimal is Dog)
                {
                    var CurrentDog = (Dog)CurrentAnimal;
                    Console.WriteLine($"- Barker: {CurrentDog.Barker}  - Race: {CurrentDog.Race}");
                }
                else if (CurrentAnimal is Cat)
                {
                    var CurrentCat = (Cat)CurrentAnimal;
                    Console.WriteLine($"- Declawed: {CurrentCat.Declawed}  - Race: {CurrentCat.Race}");
                }
                else if (CurrentAnimal is OtherAnimal)
                {
                    CurrentAnimal = (OtherAnimal)CurrentAnimal;
                }
            });




        }
    }
}
