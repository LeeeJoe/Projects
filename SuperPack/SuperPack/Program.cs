using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Experiments exps = new Experiments();
            //exps.DoExperimens();
            
            ReadyText readyText = new ReadyText();

            string file = @"\" + args[0];
            readyText.ReadText(Environment.CurrentDirectory + file);
            
            Console.WriteLine($"Initial file: {Encoding.Default.GetByteCount(readyText.Text)} bytes");

            //Console.WriteLine(readyText.GetDumpString());

            Console.WriteLine($"Count chars: {readyText.CountChars()}");
            Console.WriteLine($"Count bytes: {readyText.CountBytes()}");
            Console.WriteLine($"Count words: {readyText.CountWords()}");
            Console.WriteLine($"Count words to pack: {readyText.CountWords(9, 1, show: false)}");
            Console.WriteLine($"Count sylls: {readyText.CountSylls()}");
            Console.WriteLine($"Count sylls to pack: {readyText.CountSylls(4, 1, show: false)}");
            Console.WriteLine($"Count base52: {readyText.CountBase("AAA", show: false)}");

            // Packing
            ReadyText.Log("Packing...");
            readyText.CreatePackDictionary(9, 1, "AAA", ReadyText.PackSort.ByWords);
            readyText.PackedText = readyText.PackUnPackText(ReadyText.PackAction.Pack, true);
            readyText.SaveText(Environment.CurrentDirectory + @"\" + args[1], readyText.PackedText);
            ReadyText.Log($"Packed file: {Encoding.Default.GetByteCount(readyText.PackedText)} bytes");


            // UnPacking
            ReadyText.Log("Unpacking...");
            readyText.ReadText(Environment.CurrentDirectory + @"\" + args[1]);
            readyText.UnPackedText = readyText.PackUnPackText(ReadyText.PackAction.UnPack, true);
            readyText.SaveText(Environment.CurrentDirectory + @"\" + args[2], readyText.UnPackedText);
            ReadyText.Log($"Unpacked file: {Encoding.Default.GetByteCount(readyText.UnPackedText)} bytes");
        }
    }
}
