using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeArray
{
    class Program
    {
        static int[,] Numbers;

        static void Main(string[] args)
        {
            Console.Write("Enter dimension of array: ");
            int Dim = 0;
            if (int.TryParse(Console.ReadLine(), out Dim) && Dim > 0)
            {
                Console.WriteLine();
                Numbers = new int[Dim, Dim];

                FillArray(Numbers);
                Console.WriteLine("Start array:");
                PrintArray(Numbers);

                Console.WriteLine();

                ChangeArray(Numbers);
                Console.WriteLine("Finish array:");
                PrintArray(Numbers);
            }
            else
            {
                Console.WriteLine("Error of dimension of array");
            }
        }


        private static void FillArray(int[,] Numbers)
        {
            int k = Numbers.GetLength(1);

            for (int i = 0; i < Numbers.GetLength(0); i++)
            {
                for (int j = 0; j < Numbers.GetLength(1); j++)
                {
                    Numbers[i, j] = j + 1 + i * k;
                }
            }
        }

        private static void PrintArray(int[,] Numbers)
        {
            for (int i = 0; i < Numbers.GetLength(0); i++)
            {
                for (int j = 0; j < Numbers.GetLength(1); j++)
                {
                    Console.Write(Numbers[i, j].ToString().PadLeft(2, ' ') + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ChangeArray(int[,] Numbers)
        {
            int N = Numbers.GetLength(0) - 1;

            for (int k = 0; k < Numbers.GetLength(0) / 2; k++)
            {
                int x = Numbers[k, k];
                Numbers[k, k] = Numbers[N - k, N - k];
                Numbers[N - k, N - k] = x;

                int y = Numbers[k, N - k];
                Numbers[k, N - k] = Numbers[N - k, k];
                Numbers[N - k, k] = y;
            }
        }
    }
}
