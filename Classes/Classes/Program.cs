using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Man man1 = new Man("Peter Petrov", 19, Man.GenderEnum.Male, 77);
            Console.WriteLine(man1.ToString());

            Student student1 = new Student("Peter Petrov", 19, Man.GenderEnum.Male, 77, 2018);
            Console.WriteLine(student1.ToString());

            Student student2 = new Student("Ivan Ivanov", 20, Man.GenderEnum.Male, 75);
            student2.SetYearOfStudy(2015);
            student2.IncreaseYearOfStudy();
            Console.WriteLine(student2.ToString());

            Teacher teacher1 = new Teacher("Podskrobko Nina Igorevna", 57, Man.GenderEnum.Female, 58, Teacher.Degree.Professor, "Assembler");
            Console.WriteLine(teacher1.ToString());

            Console.WriteLine();

            Rose rose1 = new Rose(7, 2, Color.White, 90);
            Tulip tulip1 = new Tulip(5, 0.5, Color.MistyRose, 70);
            Gerber gerber1 = new Gerber(5, 1, Color.White, 80);

            Console.WriteLine(rose1.ToString());
            Console.WriteLine(tulip1.ToString());
            Console.WriteLine(gerber1.ToString());

            Console.WriteLine();

            Bouquet bouquet = new Bouquet();
            bouquet.AddFlower(rose1);
            bouquet.AddFlower(tulip1);
            bouquet.AddFlower(tulip1);
            bouquet.AddFlower(gerber1);
            bouquet.AddFlower(gerber1);

            Console.WriteLine("I am a bouquet and let me introduce myself:");
            Console.WriteLine(bouquet.ToString());
            Console.WriteLine($"and my very good price is {bouquet.GetPrice()} dollars! ;)");
        }
    }
}
