using System;
using System.Collections.Generic;
using System.Linq;



namespace Shelter.Shared
{
    class Program
    {
        static void Main(string[] args)
        {   
            var DierenbeschermingMechelen = new Shelter() {Name="Dierenbescherming Mechelen"};

            var Owner = new Person {FirstName="Thomas", LastName="Van Hemelrijk"};
            Console.WriteLine($"{Owner.FirstName} {Owner.LastName}");

            DierenbeschermingMechelen.Animals.Add(new Dog() {Name="Koda", DateOfBirth="11-02-2017", IsChecked=true, KidFriendly=true, Since="02-10-2019", Race="Husky", Barker=false});
           
            DierenbeschermingMechelen.Animals.ToList().ForEach(x => 
            {
                Console.WriteLine($"{x.Name} {x.DateOfBirth} - Checked: {x.IsChecked} - Kid friendly: {x.KidFriendly} - In shelter since: {x.Since} - Race: {x.Race} - Barker: ");
            });
            
                
            
         
        }
    }
}
