using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Shelter.Shared
{
    public class Shelters : BaseDbClass
    {
        public int ShelterId { get; set; }
        public string Name { get; set; }
        public Person Owner { get; set; }
        public string Adress { get; set; }
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
        public ICollection<Person> Employees { get; set; } = new List<Person>();
    }
}