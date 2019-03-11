using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int Dim = A.GetLength(0);

            for (int i = 0; i < Dim; i++)
            {
                Console.WriteLine($"{i + 1})");

                for (int j = 0; j < A[i]?.Length; j++)
                {
                    Console.Write($"{A[i][j]} ");
                    if (j == A[i].Length - 1) Console.WriteLine();
                }

                for (int j = 0; j < B[i]?.Length; j++)
                {
                    Console.Write($"{B[i][j]} ");
                    if (j == B[i].Length - 1) Console.WriteLine();
                }

                Console.WriteLine($"Result: {Comp(A[i], B[i])}");
            }

            Console.Write(Environment.NewLine + "Press any key to continue...");
            Console.ReadLine();
        }

        static int[][] A = new int[7][] 
        {
            null,
            Array.Empty<int>(),
            new int[] { 121, 144, 19, 161, 19, 144, 19, 11 },
            new int[] { 121, 144, 19, 161, 19, 144, 19, 11 },
            new int[] { 121, 144, 19, 161, 19, 144, 19, 11 },
            new int[] { 121, 144, 19, 161, 19, 144, 19, 11, 13, 79, 18, 169 },
            new int[] { 121, 144, 19, 161, 19, 144, 19, 11, 13, 79, 18, 169 }
        };

        static int[][] B = new int[7][]
        {
            null,
            Array.Empty<int>(),
            new int[] { 121, 14641, 20736, 361, 25921, 361, 20736, 361 },
            new int[] { 132, 14641, 20736, 361, 25921, 361, 20736, 361 },
            new int[] { 121, 14641, 20736, 36100, 25921, 361, 20736, 361 },
            new int[] { 121, 324, 14641, 169, 20736, 361, 6241, 25921, 361, 28561, 20736, 361 },
            new int[] { 121, 324, 14641, 169, 20736, 361, 6241, 25921, 361, 28562, 20736, 361 }
        };

        static bool Comp(int[] a, int[] b)
        {
            if (a == null || b == null || a?.Length == 0 || b?.Length == 0)
            {
                return false;
            }

            List<int> listA = a.ToList();
            List<int> listB = b.ToList();
            List<int> listC = new List<int>();
            listC.AddRange(listA);

            foreach (int n in listC)
            {
                if (listB.IndexOf(n * n) != -1)
                {
                    listA.Remove(n);
                    listB.Remove(n * n);
                }
            }

            return listA.Count == 0 && listB.Count == 0;
        }
    }
}
