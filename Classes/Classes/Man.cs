using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Man
    {
        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age = 0;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public enum GenderEnum
        {
            Male = 0,
            Female = 1
        }

        private GenderEnum gender = GenderEnum.Male;
        public GenderEnum Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private double weight = 0;
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Man(string name, int age, GenderEnum gender, double weight)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        public void SetWeight(double weight)
        {
            Weight = weight;
        }

        public override string ToString()
        {
            return Name + ", Gender: " + Gender + ", Age: " + Age + ", Weight: " + Weight;
        }
    }
}
