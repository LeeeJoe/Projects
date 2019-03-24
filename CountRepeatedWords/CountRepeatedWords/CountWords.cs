using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace CountRepeatedWords
{
    class CountWords
    {
        private readonly string text;

        private string[] words;

        private Dictionary<string, int> dic = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);


        public CountWords(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Message("Path cannot be null or empty...");
                return;
            }

            FileInfo fi = new FileInfo(path);

            if (fi.Exists)
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    try
                    {
                        text = sr.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        Message(ex.Message);
                    }
                }
            }
            else
            {
                Message($"File: {path} - does not exist...");
            }
        }

        public void Count()
        {
            words = GetWords();
            
            for (int i = 0; i < words.Length; i++)
            {
                if (dic.ContainsKey(words[i]))
                {
                    dic[words[i]]++;
                }
                else
                {
                    dic.Add(words[i], 1);
                }
            }
        }

        private string[] GetWords()
        {
            return text.Split(new char[] 
            {
                ' ', ',', ';', '.', '!', '?', '"', '“', '”', '«', '»', '-', '—', '–', '(', ')', '\r', '\n',
                '/', '\\', '%', '~', '@', '#', '$', '^', '&', '*', '_', '+', '=', ':', '`', '<', '>',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            }, 
            StringSplitOptions.RemoveEmptyEntries);
        }

        static void Message(string message)
        {
            Console.WriteLine(message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(text.Length);

            foreach(var p in dic)
            {
                sb.Append(p.Key + " - " + p.Value + Environment.NewLine);
            }

            return sb.ToString();
        }

        public string ToStringSorted()
        {
            StringBuilder sb = new StringBuilder(text.Length);

            SortedDictionary<string, int> sdic = new SortedDictionary<string, int>(dic);

            foreach (var p in sdic)
            {
                sb.Append(p.Key + " - " + p.Value + Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
