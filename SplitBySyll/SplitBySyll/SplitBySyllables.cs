using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitBySyll
{
    public class SplitBySyllables
    {
        private static readonly string[] VowLetter = new string[] { "А", "Е", "Ё", "И", "О", "У", "Ы", "Э", "Ю", "Я" };

        private string Text;

        private string[] ArrWords;
        private string[] NewWords;

        public SplitBySyllables()
        {

        }

        public SplitBySyllables(string text)
        {
            Text = text;
        }

        private string[] GetWords()
        {
            return Text.Split(new char[] { ' ', ',', ';', '.', '!', '?', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
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

            ArrWords = GetWords();
            NewWords = GetWords();

            for (int i = 0; i < NewWords.Length; i++)
            {
                NewWords[i] = InsHyphen(NewWords[i]);
                Text = Text.Replace(ArrWords[i], NewWords[i]);
            }

            return Text;
        }

        public string Parse()
        {
            return DoParse();
        }

        public string Parse(string text)
        {
            Text = text;

            return DoParse();
        }
    }
}
