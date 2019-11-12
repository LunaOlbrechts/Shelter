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
            var DierenbeschermingMechelen = new Shelters() { Name = "Dierenbescherming Mechelen" };
            // make new object of person
            var Owner = new Person { FirstName = "Thomas", LastName = "Van Hemelrijk" };
            var Dog1 = new Dog() { Name = "Koda", DateOfBirth = "11-02-2017", IsChecked = true, KidFriendly = true, Since = "02-10-2019", Race = "Husky", Barker = false };
            var Caretaker1 = new Caretaker() { FirstName = "lissa" };
            Caretaker1.Animals.Add(Dog1);
            var Caretaker2 = new Caretaker() { FirstName = "Luna" };
            DierenbeschermingMechelen.Employees.Add(Caretaker1);
            DierenbeschermingMechelen.Employees.Add(Caretaker2);


            DierenbeschermingMechelen.Employees.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.FirstName}");
            });

            Caretaker1.Animals.ToList().ForEach(Currentlist =>
           {
               Console.WriteLine($"{Currentlist.Name}");
           });

            DierenbeschermingMechelen.Animals.Add(Dog1);
            // print list of animals
            DierenbeschermingMechelen.Animals.ToList().ForEach(CurrentAnimal =>
            {
                Console.WriteLine($"{CurrentAnimal.Name} {CurrentAnimal.DateOfBirth} - Checked: {CurrentAnimal.IsChecked} - Kid friendly: {CurrentAnimal.KidFriendly} - In shelter since: {CurrentAnimal.Since} - Race: {CurrentAnimal.Race}");

                if (CurrentAnimal is Dog)
                {
                    var CurrentDog = (Dog)CurrentAnimal;
                    Console.WriteLine($"- Barker: {CurrentDog.Barker}");
                }
                else if (CurrentAnimal is Cat)
                {
                    var CurrentCat = (Cat)CurrentAnimal;
                    Console.WriteLine($"- Declawed: {CurrentCat.Declawed}");
                }
                else if (CurrentAnimal is OtherAnimal)
                {
                    CurrentAnimal = (OtherAnimal)CurrentAnimal;
                }
            });




        }
    }
}
