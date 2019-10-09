using System;
using System.Linq;

namespace Shelter.Shared
{
   public class Person{
        public string FullName => $"{LastName}, ${FirstName}";
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string BirthDate {get; set;}
    }

    public class Employee : Person{

    }

    public class Caretaker : Employee{

    }
    public class Manager : Employee{
       
    }
    public class Administrator : Employee{
       
    }
    public class Owner : Employee{
    }
}