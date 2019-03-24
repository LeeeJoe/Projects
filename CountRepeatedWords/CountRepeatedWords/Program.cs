using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRepeatedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            CountWords countWords = new CountWords(Environment.CurrentDirectory + @"\text.txt");

            countWords.Count();

            Console.WriteLine(countWords.ToString());

            Console.WriteLine();

            Console.WriteLine(countWords.ToStringSorted());
        }
    }
}
