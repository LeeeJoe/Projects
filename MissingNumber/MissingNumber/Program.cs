using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //To test one string
            //int Res = GetMissing(StringArr[18]);
            //Console.WriteLine($"String: {StringArr[18]}, missing: {Res}");

            for (int i = 0; i < StringArr.Length; i++)
            {
                int Res = GetMissing(StringArr[i]);
                Console.WriteLine($"String: {StringArr[i]}, missing: {Res}");
            }
        }

        static string[] StringArr = new string[]
        {
            "123456a789",
            "12-3456789",
            "123567",
            "78101112",
            "8990919395",
            "9899101102",
            "599600601602",
            "899192939495",
            "888889890892",
            "789791792",
            "678679681682683",
            "6789101213",
            "78101112",
            "97100101102",
            "678679681683",
            "567856795680568156825683",
            "56785680568156825683",
            "56785679568156825683",
            "56785679568056825683",
            "5678567956815683",
            "997998999100010011002",
            "997998100010011002",
            "99799899910011002",
            "99799910011002",
            "123456789101112131415161718192021222324252627283031",
            "119121122123"
        };

        static int GetMissing(string S)
        {
            if (string.IsNullOrEmpty(S)) return -1;

            Regex regex = new Regex(@"\D", RegexOptions.IgnoreCase);

            int Res = 0;                //Result
            int Dim = 1;                //Dimension
            int First = 0;              //First number
            string FirstAsString = "";  //First number as string
            int Second = 0;             //Second number
            string SecondAsString = ""; //Second number as string

            int i = 0;                  //String index
            do
            {
                if (regex.IsMatch(S)) return -1;

                FirstAsString = S.Substring(i, Dim);
                First = GetNumber(FirstAsString);
                Second = First + 1;
                SecondAsString = Second.ToString();

                if (FirstAsString.Length + SecondAsString.Length > S.Length) return -1;

                if (IsEquals(S, FirstAsString + SecondAsString, i))
                {
                    i += FirstAsString.Length;
                    Dim = SecondAsString.Length;
                }
                else
                {
                    Second = First + 2;
                    SecondAsString = Second.ToString();

                    if (IsEquals(S, FirstAsString + SecondAsString, i))
                    {
                        if (Res == 0)
                        {
                            Res = First + 1;
                        }
                        else
                        {
                            return -1;
                        }

                        i += FirstAsString.Length;
                        Dim = SecondAsString.Length;
                    }
                    else
                    {
                        if (i > 0) i = 0;
                        Dim++;
                    }
                }
            }
            while (i < S.Length - Dim);

            return Res != 0 ? Res : -1;
        }

        
        static int GetNumber(string S)
        {
            if (!int.TryParse(S, out int N)) N = -1;

            return N;
        }

        static bool IsEquals(string S, string SubS, int index)
        {
            return S.Substring(index, SubS.Length) == SubS;
        }
    }
}
