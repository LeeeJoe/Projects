using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitBySyll
{
    class Program
    {
        static string Text =
@"Я сразу смазал карту будня,
плеснувши краску из стакана;
я показал на блюде студня
косые скулы океана.
На чешуе жестяной рыбы
прочёл я зовы новых губ.
А вы ноктюрн сыграть
могли бы?
на флейте водосточных труб?

остеохандроз глаукома подросток ростовщик рассчитанный растительный педераст портсигар 
картинка ребята калитка лагерь стройка лейка сядьте крыльцо подъезд ойкумена плеснувши
Гамсахурдия Паулиашвили швея пересвист сверестель стелька нерест стрептоцид
освобождение переохлаждение";

        static void Main(string[] args)
        {
            SplitBySyllables bySyllables = new SplitBySyllables();

            Text = bySyllables.Parse(Text);

            Console.WriteLine(Text);

            string path = Environment.CurrentDirectory + @"\readme.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(Text);
            }
        }
    }
}
