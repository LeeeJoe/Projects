using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Student : Man
    {
        private int yearOfStudy = 0;
        public int YearOfStudy
        {
            get { return yearOfStudy; }
            set { yearOfStudy = value; }
        }

        public Student(string name, int age, GenderEnum gender, double weight)
            : base(name, age, gender, weight)
        {
            
        }

        public Student(string name, int age, GenderEnum gender, double weight, int yearOfStudy) 
            : base(name, age, gender, weight)
        {
            YearOfStudy = yearOfStudy;
        }

        public void SetYearOfStudy(int yearOfStudy)
        {
            YearOfStudy = yearOfStudy;
        }

        public void IncreaseYearOfStudy()
        {
            YearOfStudy++;
        }

        public override string ToString()
        {
            return base.ToString() + ", Year of study: " + YearOfStudy;
        }
    }
}
