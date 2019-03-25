using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySortedList
{
    class GSortedList<T> : IEnumerable<T>, IComparable<T>
    {
        private Node<T> first;

        private int count;
        public int Count
        {
            get { return count; }
        }
        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public GSortedList()
        {
            first = null;
        }

        public void Add(T data)
        {
            Node<T> n = new Node<T>(data) { Next = first };
            first = n;
            count++;
            Sort();
        }

        public bool Remove(T data)
        {
            Node<T> current = first;
            Node<T> previous = null;

            if (IsEmpty) return false;

            while (current != null) 
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        first = first.Next;
                    }

                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = first;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        private void Sort()
        {
            if (Count >= 2)
            {
                Node<T> current = first;

                while (current.Next != null)
                {
                    #region old variant
                    //Node<T> n1 = current;
                    //Node<T> n2 = current.Next;
                    //int I = n1.CompareTo(n2.Data);

                    //if (I > 0)
                    //{
                    //    Node<T> node = new Node<T>() { Data = current.Data };
                    //    current.Data = current.Next.Data;
                    //    current.Next.Data = node.Data;
                    //    current = current.Next;
                    //}
                    //else
                    //{
                    //    current = current.Next;
                    //}
                    #endregion

                    if (current.CompareTo(current.Next.Data) > 0)
                    {
                        Node<T> node = new Node<T>() { Data = current.Data };
                        current.Data = current.Next.Data;
                        current.Next.Data = node.Data;
                    }

                    current = current.Next;
                }
            }
        }

        public override string ToString()
        {
            string s = "";

            foreach(T v in this)
            {
                s += v.ToString() + " "; 
            }

            return s;
        }

        public int CompareTo(T other)
        {
            return CompareTo(other);
        }
    }
}
