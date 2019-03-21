using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParser
{
    class Program
    {
        static void ShowArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            DeadFish deadFish = new DeadFish();

            int[] Arr = deadFish.Parse("iiisdoso");

            ShowArray(Arr);


            DeadFish deadFish2 = new DeadFish("ixicisdioso");

            Arr = deadFish2.Parse();

            ShowArray(Arr);
        }
    }
}
