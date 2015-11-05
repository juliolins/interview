using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.DataStructures
{
    public class LinkedListTests
    {
        public static void Test()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(4);

            list.PrintToConsole();
            list.RemoveDuplicates();
            list.PrintToConsole();
        }
    }


    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;

        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node<T>() { Value = value };
                tail = head;
            }
            else
            {
                tail.Next = new Node<T>() { Value = value };
                tail = tail.Next;
            }
        }

        public void RemoveDuplicates()
        {
            if (head == null) return;

            var present = new Dictionary<T, bool>();
            present.Add(head.Value, true);
            var current = head;

            while (current.Next != null)
            {
                if (present.ContainsKey(current.Next.Value))
                {
                    //don't update current in this case
                    current.Next = current.Next.Next;
                }
                else
                {
                    //just move to next
                    current = current.Next;
                    present.Add(current.Value, true);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(head); ;
        }

        class ListEnumerator<U> : IEnumerator<U>
        {
            private Node<U> current;

            public ListEnumerator(Node<U> head)
            {
                current = new Node<U>() { Next = head};
            }

            public U Current
            {
                get { return current.Value; }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                current = current.Next;
                return current != null;
            }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        class Node<U>
        {
            public U Value { get; set; }
            public Node<U> Next { get; set; }
        }

    }
}
