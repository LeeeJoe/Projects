using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Teacher : Man
    {
        public enum Degree
        {
            AssistantProfessor = 0,
            Professor = 1,
            Doctor = 2,
            CorrespondingMember = 3
        }

        private Degree academicDegree = 0;
        public Degree AcademicDegree
        {
            get { return academicDegree; }
            set { academicDegree = value; }
        }

        private string subject = "";
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public Teacher(string name, int age, GenderEnum gender, double weight)
            : base(name, age, gender, weight)
        {

        }

        public Teacher(string name, int age, GenderEnum gender, double weight, Degree degree, string subject)
            : base(name, age, gender, weight)
        {
            AcademicDegree = degree;
            Subject = subject;
        }

        public void SetDegree(Degree degree)
        {
            AcademicDegree = degree;
        }

        public void SetSubject(string subject)
        {
            Subject = subject;
        }

        public override string ToString()
        {
            return base.ToString() + ", Degree: " + AcademicDegree + ", Subject: " + Subject;
        }
    }
}
