using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParser
{
    public class DeadFish
    {
        private List<int> listInt = new List<int>();
        private string strToParse = "";
        private int Count = 0;

        public DeadFish()
        {

        }

        public DeadFish(string stringToParse)
        {
            strToParse = stringToParse;
        }

        public int[] Parse()
        {
            DoParse();

            return listInt.ToArray();
        }

        public int[] Parse(string stringToParse)
        {
            strToParse = stringToParse;

            DoParse();

            return listInt.ToArray();
        }

        private void DoParse()
        {
            for (int i = 0; i < strToParse.Length; i++)
            {
                switch (strToParse[i])
                {
                    case 'd':
                        Dec();
                        break;
                    case 'i':
                        Inc();
                        break;
                    case 's':
                        Square();
                        break;
                    case 'o':
                        AddToList();
                        break;
                }
            }
        }

        private void Dec()
        {
            Count--;
        }

        private void Inc()
        {
            Count++;
        }

        private void Square()
        {
            Count *= Count;
        }

        private void AddToList()
        {
            listInt.Add(Count);
        }
    }
}
