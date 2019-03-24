using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test 1
            GList<string> list1 = new GList<string>(10);

            for (int i = 9; i >= 0; i--)
            {
                try
                {
                    list1.Add((i + 1).ToString().PadLeft(3, '0'));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(list1.ToString());


            //Test 2
            GList<string> list2 = new GList<string>();

            for (int i = 4; i >= 0; i--)
            {
                try
                {
                    list2.Add((i + 1).ToString().PadLeft(3, '0'));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            list2[4] = "SSS";

            list2.Insert("XXX", 0);

            list2.Insert("zzz", 3);

            list2.Insert("aaa", 3);

            Console.WriteLine(list2.ToString());

            list2.Sort();

            Console.WriteLine(list2.ToString());

            foreach(var l in list2)
            {
                Console.WriteLine(l.ToString());
            }
        }
    }
}
