using System;
using System.Linq;
using System.Collections.Generic;

namespace Shelter.Shared
{
    public class Person : BaseDbClass
    {
        public string FullName => $"{LastName}, ${FirstName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
    }
    public class Employee : Person
    {
    }
    public class Caretaker : Employee
    {
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
    public class Administrator : Employee
    {
    }
    public class Owner : Employee
    {
    }
}