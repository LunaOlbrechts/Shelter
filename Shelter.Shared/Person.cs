using System;
using System.Collections.Generic;
using System.Linq;

namespace Shelter.Shared
{
    public class Person
    {
        public string FullName => $"{LastName}, ${FirstName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
<<<<<<< HEAD
    public class Caretaker : Person{
        
=======
    public class Employee : Person
    {

>>>>>>> 15b2a1fffe6bc97a9986e83acfe19e06d008216a
    }
    public class Caretaker : Employee
    {
       public ICollection<Animal> CaretakerAnimals {get; set;} = new List<Animal>();
    }
    public class Manager : Employee
    {

    }
    public class Administrator : Employee
    {

    }
    public class Owner : Person
    {

    }
}