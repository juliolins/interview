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

            //list.DeleteFromMiddle(2);
            //list.PrintToConsole();
            //list.DeleteFromMiddle(3);
            //list.PrintToConsole();

            //var list1 = new LinkedList<int>();
            //list1.Add(3);
            //list1.Add(1);
            //list1.Add(5);

            //var list2 = new LinkedList<int>();
            //list2.Add(5);
            //list2.Add(9);
            //list2.Add(2);
            //list2.Add(1);

            //var listSum = LinkedList<int>.AddInt(list1, list2);
            //listSum.PrintToConsole();

            list.MakeCircular(2);
            Console.WriteLine("Circular node = " + list.FindCircularValue());
        }
    }


    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;

        private LinkedList(Node<T> node)
        {
            head = node;
            tail = node;
        }

        public LinkedList()
        {
        }

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

            tail = current;
        }

        public void DeleteFromMiddle(T value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    DeleteFromMiddle(current);
                    return;
                }

                current = current.Next;
            }
        }

        private void DeleteFromMiddle(Node<T> node)
        {
            //find node
            var current = head;
            while (current.Next != node)
            {
                current = current.Next;
            }

            while (current.Next.Next != null)
            {
                current.Next.Value = current.Next.Next.Value;
                current = current.Next;
            }

            //remove last node
            current.Next = null;
        }

        public static LinkedList<int> AddInt(LinkedList<int> list1, LinkedList<int> list2)
        {
            LinkedList<int>.Node<int> headSum = null;
            LinkedList<int>.Node<int> tailSum = null;

            var current1 = list1.head;
            var current2 = list2.head;
            var rest = 0;

            while (current1 != null || current2 != null)
            {
                int value1 = current1 != null ? current1.Value : 0;
                int value2 = current2 != null ? current2.Value : 0;

                int sum = value1 + value2 + rest;

                rest = sum / 10;
                sum = sum % 10;

                AddNode(ref headSum, ref tailSum, new LinkedList<int>.Node<int>() { Value = sum });

                if (current1 != null) current1 = current1.Next;
                if (current2 != null) current2 = current2.Next;
            }

            if (rest > 0)
            {
                AddNode(ref headSum, ref tailSum, headSum);
            }

            return new LinkedList<int>(headSum);
        }

        public void MakeCircular(T value)
        {
            //find node with value
            var current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    break;
                }

                current = current.Next;
            }

            if (current == null)
            {
                return;
            }

            tail.Next = current;
        }

        public T FindCircularValue()
        {
            var visited = new Dictionary<LinkedList<T>.Node<T>, bool>(); 
            var current = head;

            while (current != null)
            {
                if (visited.ContainsKey(current))
                {
                    return current.Value;
                }
                else
                {
                    visited.Add(current, true);
                    current = current.Next;
                }
            }

            throw new Exception("Not a circular list");
        }

        private static void AddNode<U>(ref LinkedList<U>.Node<U> head, ref LinkedList<U>.Node<U> tail, LinkedList<U>.Node<U> node)
        {
            if (head == null)
            {
                head = node;
                tail = head;
            }
            else
            {
                tail.Next = node;
                tail = tail.Next;
            }
        }

        private static int GetIntValue(Node<int> node)
        {
            if (node == null) return 0;
            else return node.Value;
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
