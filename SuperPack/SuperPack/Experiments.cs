using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPack
{
    // Temporary class
    class Experiments
    {
        readonly string[] strings = { "Hello world!", "\r\n", "Как жизнь?" };
        Encoding encodingKind = Encoding.Default;
        byte[] bytes = new byte[49];

        int index = 0;

        public Experiments()
        {

        }

        public void DoExperimens()
        {
            Console.WriteLine("Start experiment...");
            Console.WriteLine("Strings to encode:");
            foreach (var s in strings)
            {
                Console.Write(s);

                int count = encodingKind.GetByteCount(s);
                if (count + index >= bytes.Length)
                {
                    Array.Resize(ref bytes, bytes.Length + 50);
                }

                int written = encodingKind.GetBytes(s, 0, s.Length, bytes, index);

                index += written;
            }
            Console.WriteLine();

            string newString = encodingKind.GetString(bytes, 0, index);
            Console.WriteLine("Decoded:");
            Console.WriteLine(newString);
            Console.WriteLine("Stop experiment...\r\n");
        }
        
    }
}
