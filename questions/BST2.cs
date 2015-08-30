using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class TestBST2
    {
        public static void Test()
        {
            BST2<int, string> bst = new BST2<int, string>();

            bst.Add(1, "one");
            bst.Add(4, "four");
            bst.Add(7, "seven");
            bst.Add(3, "three");
            bst.Add(8, "eight");
            bst.Add(6, "six");
            bst.Add(2, "two");
            bst.Add(5, "five");

            var values = bst.Values;

            Console.WriteLine();
            foreach (var value in values)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
    }

    public class BST2<TKey, TValue> where TKey : IComparable
    {

        private Node<TKey, TValue> root;

        public void Add(TKey key, TValue value)
        {
            var node = new Node<TKey, TValue>() { Key = key, Value = value };

            root = DoAdd(root, node);
        }


        private Node<TKey, TValue> DoAdd(Node<TKey, TValue> current, Node<TKey, TValue> newNode)
        {
            if (current == null)
            {
                return newNode;
            }

            if (newNode.Key.CompareTo(current.Key) < 0)
            {
                current.Left = DoAdd(current.Left, newNode);
            }
            else
            {
                current.Right = DoAdd(current.Right, newNode);
            }

            return current;
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();
                Stack<Node<TKey, TValue>> stack = new Stack<Node<TKey, TValue>>();
                var current = root;

                while (current != null || stack.Count > 0)
                {
                    if (current == null)
                    {
                        current = stack.Pop();
                        values.Add(current.Value);
                        current = current.Right;
                    }
                    else
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                return values;
            }
        }

        private class Node<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }

            public Node<TKey, TValue> Left { get; set; }
            public Node<TKey, TValue> Right { get; set; }
        }
    }
}
