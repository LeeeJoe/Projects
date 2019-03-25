using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySortedList
{
    class Node<T> : IComparable<T>, IComparer<T>
    {
        private Node<T> next;
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node(T d)
        {
            Next = null;
            Data = d;
        }

        public Node() : this(default(T))
        {

        }

        public int CompareTo(T other)
        {
            return Compare(Data, other); 
        }

        public int Compare(T x, T y)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            return comparer.Compare(x, y);
        }
    }
}
