using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPack
{
    class ReadyText
    {
        private static readonly string[] VowLetter = new string[] { "А", "Е", "Ё", "И", "О", "У", "Ы", "Э", "Ю", "Я" };

        private string text;
        public string Text
        {
            get { return text; }
        }

        private string packedText;
        public string PackedText
        {
            get { return packedText; }
            set { packedText = value; }
        }

        private string unPackedText;
        public string UnPackedText
        {
            get { return unPackedText; }
            set { unPackedText = value; }
        }

        private string currentBase52;
        public string CurrentBase52
        {
            get { return currentBase52; }
        }

        private SortedList<char, int> dicChars = new SortedList<char, int>();

        private SortedList<byte, int> dicBytes = new SortedList<byte, int>();

        private SortedList<string, int> dicWords = new SortedList<string, int>();

        private SortedList<string, int> dicSylls = new SortedList<string, int>();

        private SortedList<string, string> dicPack = new SortedList<string, string>();

        private SortedList<string, string> dicUnPack = new SortedList<string, string>();

        
        private string[] arrWords;
        private string[] newWords;


        public ReadyText()
        {
            
        }

        public int CountChars()
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (dicChars.ContainsKey(text[i]))
                {
                    dicChars[text[i]]++;
                }
                else
                {
                    dicChars.Add(text[i], 1);
                }
            }

            return dicChars.Count;
        }

        public int CountBytes()
        {
            Encoding encodingKind = Encoding.Default;
            byte[] bytes = new byte[encodingKind.GetByteCount(text)];
            int count = encodingKind.GetBytes(text, 0, text.Length, bytes, 0);

            for (int i = 0; i < bytes.Length; i++)
            {
                if (dicBytes.ContainsKey(bytes[i]))
                {
                    dicBytes[bytes[i]]++;
                }
                else
                {
                    dicBytes.Add(bytes[i], 1);
                }
            }

            return dicBytes.Count;
        }

        public int CountWords()
        {
            string[] words = GetWords();

            for (int i = 0; i < words.Length; i++)
            {
                if (dicWords.ContainsKey(words[i]))
                {
                    dicWords[words[i]]++;
                }
                else
                {
                    dicWords.Add(words[i], 1);
                }
            }

            return dicWords.Count;
        }

        public int CountWords(int lengthMin, int countMin, bool show)
        {
            if (dicWords.Count == 0)
            {
                CountSylls();
            }

            string s = "";
            int occure = 0;
            int val = 0;

            foreach (var k in dicWords.Keys)
            {
                if (k.Length >= lengthMin && dicWords[k] >= countMin)
                {
                    if (show) { s += k + " - " + dicWords[k] + Environment.NewLine; }
                    occure++;
                    val += dicWords[k];
                }
            }

            if (show) { Console.WriteLine(s + "All occured: " + occure + " Count: " + val); }

            return occure;
        }

        public int CountSylls()
        {
            DoParse();

            List<string> list = new List<string>();

            for (int i = 0; i < newWords.Length; i++)
            {
                string[] sylls = newWords[i].Split(new char[] { '-' });
                list.AddRange(sylls);
            }

            string[] words = list.ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                if (dicSylls.ContainsKey(words[i]))
                {
                    dicSylls[words[i]]++;
                }
                else
                {
                    dicSylls.Add(words[i], 1);
                }
            }

            return dicSylls.Count;
        }

        public int CountSylls(int lengthMin, int countMin, bool show)
        {
            if (dicSylls.Count == 0)
            {
                CountSylls();
            }

            string s = "";
            int occure = 0;
            int val = 0;

            foreach (var k in dicSylls.Keys)
            {
                if (k.Length >= lengthMin && dicSylls[k] >= countMin)
                {
                    if (show) { s += k + " - " + dicSylls[k] + Environment.NewLine; }
                    occure++;
                    val += dicSylls[k];
                }
            }

            if (show) { Console.WriteLine(s + "All occured: " + occure + " Count: " + val); }

            return occure;
        }

        public int CountBase(string start, bool show)
        {
            string b52 = start;
            int i = 0;

            do
            {
                if (show) { Console.WriteLine($"{i.ToString().PadLeft(b52.Length, '0')}) Base52: {b52}"); }
                b52 = GetNextBase52(b52);
                i++;
            }
            while (b52 != start);

            return i;
        }

        public string GetNextBase52(string start)
        {
            StringBuilder sb = new StringBuilder(start);
            bool up = false;
            int i = sb.Length - 1;

            do
            {
                switch (sb[i])
                {
                    case 'Z':
                        sb[i] = 'a';
                        if (up) { up = false; }
                        break;
                    case 'z':
                        sb[i] = 'A';
                        up = true;
                        break;
                    default:
                        sb[i]++;
                        if (up) { up = false; }
                        break;
                }

                i--;
            }
            while (up && i >= 0);

            return sb.ToString();
        }

        public void CreatePackDictionary(int lengthMin, int countMin)
        {
            currentBase52 = "AA";

            foreach (var k in dicSylls.Keys)
            {
                if (k.Length >= lengthMin && dicSylls[k] >= countMin)
                {
                    dicPack.Add(k, "#" + currentBase52);
                    currentBase52 = GetNextBase52(currentBase52);
                }
            }
        }

        public void CreateUnPackDictionary()
        {
            foreach (var k in dicPack.Keys)
            {
                dicUnPack.Add(dicPack[k], k);
            }
        }

        public enum PackAction
        {
            Pack = 0,
            UnPack = 1
        }

        public string PackUnPackText(PackAction action, bool show)
        {
            StringBuilder sb = new StringBuilder(text);

            //SortedList<string, string> pairs = action == PackAction.Pack ? dicPack : dicUnPack;
            SortedList<string, string> pairs = dicPack;

            int count = 0;
            foreach (var k in pairs.Keys)
            {
                if (action == PackAction.Pack)
                {
                    sb.Replace(k, pairs[k]);
                }
                else
                {
                    sb.Replace(pairs[k], k);
                }
                
                count++;

                if (show) { Console.Write($"Processed pairs: {count}\r"); }
            }

            if (show) Console.WriteLine();

            return sb.ToString();
        }


        public void ReadText(string path)
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

        public void SaveText(string path, string text)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                try
                {
                    sw.Write(text);
                }
                catch (Exception ex)
                {
                    Message(ex.Message);
                }
            }
        }


        private string[] GetWords()
        {
            return text.Split(new char[]
            {
                ' ', ',', ';', '.', '!', '?', '"', '“', '”', '„', '«', '»', '-', '—', '–', '(', ')', '\r', '\n',
                '/', '\\', '%', '~', '@', '#', '$', '^', '&', '*', '_', '+', '=', ':', '`', '<', '>', '…',
                ' ', '\t', '[', ']',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            },
            StringSplitOptions.RemoveEmptyEntries);
        }

        private static string InsHyphen(string word)
        {
            if (CountVowel(word) <= 1) return word;

            for (int i = 0; i < VowLetter.Length; i++)
            {
                int idx = 0;

                do
                {
                    idx = word.ToUpper().IndexOf(VowLetter[i], idx);

                    if (idx > -1 && idx < word.Length - 1)
                    {
                        if (idx < word.Length - 2)
                        {
                            if (!IsVowel(word[idx + 1].ToString()) && !IsVowel(word[idx + 2].ToString()))
                            {
                                idx++;

                                switch (word[idx].ToString().ToUpper())
                                {
                                    case "Й":
                                        break;
                                    case "Р":
                                        if (word[idx + 1].ToString().ToUpper() == "Т")
                                        {
                                            if (idx >= 2 && word.Substring(idx - 2, 2).ToUpper() == "ПО")
                                            {
                                                idx++;
                                            }
                                        }
                                        break;
                                    case "С":
                                        if (word[idx + 1].ToString().ToUpper() == "Т")
                                        {
                                            if (idx >= 2 && word.Substring(idx - 2, 2).ToUpper() == "ДО")
                                            {
                                                idx--;
                                            }
                                        }

                                        if (word[idx + 1].ToString().ToUpper() == "В")
                                        {
                                            idx--;
                                        }
                                        break;
                                    case "Ш":
                                        if (word[idx + 1].ToString().ToUpper() == "В")
                                        {
                                            idx--;
                                        }
                                        break;
                                    default:
                                        if (word[idx + 1].ToString().ToUpper() == "Ь" ||
                                            word[idx + 1].ToString().ToUpper() == "Ъ")
                                        {
                                            idx++;
                                        }
                                        break;
                                }
                            }
                        }

                        idx++;

                        if (idx < word.Length - 1)
                        {
                            word = word.Insert(idx, "-");
                        }
                        else
                        {
                            if (idx == word.Length - 1 && IsVowel(word[idx].ToString().ToUpper()))
                            {
                                word = word.Insert(idx, "-");
                            }
                        }
                    }
                    else
                    {
                        idx = -1;
                    }
                }
                while (idx != -1);
            }

            return word;
        }

        private static bool IsVowel(string ch)
        {
            bool res = false;

            for (int i = 0; i < VowLetter.Length; i++)
            {
                if (ch.ToUpper() == VowLetter[i])
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        private static int CountVowel(string word)
        {
            int Count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < VowLetter.Length; j++)
                {
                    if (word[i].ToString().ToUpper() == VowLetter[j])
                    {
                        Count++;
                    }
                }
            }

            return Count;
        }

        private string DoParse()
        {
            if (string.IsNullOrEmpty(Text))
            {
                throw new ArgumentException("Argument cannot be null or empty.");
            }

            arrWords = GetWords();
            newWords = GetWords();

            for (int i = 0; i < newWords.Length; i++)
            {
                newWords[i] = InsHyphen(newWords[i]);
            }

            return Text;
        }

        private static void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string GetDumpText()
        {
            string s = "";

            Encoding encodingKind = Encoding.Default; //Encoding.BigEndianUnicode;
            byte[] bytes = new byte[encodingKind.GetByteCount(text)];
            int count = encodingKind.GetBytes(text, 0, text.Length, bytes, 0);

            foreach (byte b in bytes)
            {
                s += String.Format("{0:X2} ", b);
            }

            s += "\r\n";

            for (int i = 0; i < text.Length; i++)
            {
                s += String.Format("{0:X2} ", (int)text[i]);
            }

            return s;
        }

        public override string ToString()
        {
            return text;
        }
    }
}
