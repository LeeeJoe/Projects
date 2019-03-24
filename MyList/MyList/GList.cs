using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class GList<E> where E : IComparable<E>
    {
        private E[] arr;
        private const int DEF_SIZE = 10;
        private int idx = 0;

        public int Capacity
        {
            get { return arr.Length; }
        }

        public int Count
        {
            get { return idx; }
        }

        public E this[int index]
        {
            get
            {
                if (index < 0 || index > idx)
                {
                    throw new ListException("Index out of range.");
                }

                return arr[index];
            }
            set
            {
                Insert(value, index);
            }
        }

        public GList(int count)
        {
            if (count <= 0)
            {
                throw new ListException("Invalid list size.");
            }
            
            arr = new E[count];
        }

        public GList() : this(DEF_SIZE)
        {

        }

        public void Add(E item)
        {
            if (idx == arr.Length)
            {
                throw new ListException("List overflow.");
            }

            arr[idx++] = item;
        }

        public void Insert(E item, int index)
        {
            if (index >= idx)
            {
                throw new ListException("Cannot insert after last element.");
            }

            if (this.idx == arr.Length)
            {
                throw new ListException("List overflow.");
            }

            for (int i = idx; i > index; i--)
            {
                arr[i] = arr[i - 1];
            }
            
            arr[index] = item;
            idx++;
        }

        public IEnumerator<E> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return arr[i];
            }
        }

        public void Sort()
        {
            Array.Sort(arr, 0, idx);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                sb.Append(arr[i].ToString());
                if (i < Count - 1) sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}
