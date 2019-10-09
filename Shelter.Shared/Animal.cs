using System;
using System.Collections.Generic;
using System.Linq;

namespace Shelter.Shared
{
     public class Animal{
        public string Name {get; set;}
        public string DateOfBirth {get; set;}
        public bool IsChecked {get; set;}
        public bool KidFriendly {get; set;}
        public string Since {get; set;}
        public string Race {get; set;}


    }

    public class Dog : Animal
    {
       public bool Barker {get; set;}
    }

    public class Cat : Animal
    {
       public bool Declawed {get; set;}
    }

     public class OtherAnimal : Animal
    {
       public string Description {get; set;}
       public string Kind {get; set;}
    }
}