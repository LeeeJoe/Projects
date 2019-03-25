using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySortedList
{
    class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person() : this ("", 0)
        {
            
        }

        public override string ToString()
        {
            return Name + "-" + Age;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person p))
            {
                return false;
            }

            return Name == p.Name && Age == p.Age;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Person p))
            {
                return -1;
            }

            if (Name == p.Name)
            {
                return Age.CompareTo(p.Age);
            }
            else
            {
                return Name.CompareTo(p.Name);
            }
        }
    }
}
