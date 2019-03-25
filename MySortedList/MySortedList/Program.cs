using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test 1");
            GSortedList<int> sl1 = new GSortedList<int>();
            for (int i = 0; i < 10; i++)
            {
                sl1.Add(i);
            }
            sl1.Add(1);
            Console.WriteLine($"Всего элементов: {sl1.Count}");
            Console.WriteLine(sl1.ToString());

            int i1 = 5;
            int i2 = 0;
            if (sl1.Remove(i1)) { Console.WriteLine("Удален элемент: {0}", i1); }
            if (sl1.Remove(i2)) { Console.WriteLine("Удален элемент: {0}", i2); }

            Console.WriteLine($"Всего элементов: {sl1.Count}");
            Console.WriteLine(sl1.ToString());
            Console.WriteLine();


            Console.WriteLine("Test 2");
            GSortedList<string> sl2 = new GSortedList<string>();
            for (int i = 0; i < 10; i++)
            {
                sl2.Add(i.ToString().PadLeft(3, '0'));
            }
            sl2.Add("000");
            sl2.Add("000");
            Console.WriteLine($"Всего элементов: {sl2.Count}");
            Console.WriteLine(sl2.ToString());

            string s1 = "009";
            string s2 = "000";
            if (sl2.Remove(s1)) { Console.WriteLine("Удален элемент: {0}", s1); }
            if (sl2.Remove(s2)) { Console.WriteLine("Удален элемент: {0}", s2); }

            Console.WriteLine($"Всего элементов: {sl2.Count}");
            Console.WriteLine(sl2.ToString());
            Console.WriteLine();


            Console.WriteLine("Test 3");
            Random random = new Random();
            GSortedList<Person> sl3 = new GSortedList<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person p = new Person()
                {
                    //Name = "N_" + random.Next(0, 999).ToString().PadLeft(3, '0'),
                    //Age = random.Next(10, 80)
                    Name = "Name" + i.ToString().PadLeft(3, '0'),
                    Age = 20 + i
                };
                sl3.Add(p);
            }
            Console.WriteLine($"Всего элементов: {sl3.Count}");
            Console.WriteLine(sl3.ToString());

            Person p1 = new Person("Name008", 28);
            if (sl3.Remove(p1)) { Console.WriteLine("Удален элемент: {0}", p1); }

            Console.WriteLine($"Всего элементов: {sl3.Count}");
            Console.WriteLine(sl3.ToString());

            sl3.Add(new Person("Name003", 20));
            sl3.Add(new Person("Name003", 28));

            Console.WriteLine($"Всего элементов: {sl3.Count}");
            Console.WriteLine(sl3.ToString());
        }
    }
}
