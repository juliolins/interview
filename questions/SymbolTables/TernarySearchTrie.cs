using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.SymbolTables
{
    public class TernarySearchTrie<T>
    {
        private Node<T> root;


        public void Add(string key, T value)
        {
            root = Add(root, key, value, 0);
        }

        private Node<T> Add(Node<T> node, string key, T value, int keyIndex)
        {
            if (node == null)
            {
                node = new Node<T>() { Char = key[keyIndex] };
            }

            if (keyIndex == key.Length - 1)
            {
                node.Value = value;
            }
            else if (key[keyIndex] == node.Char)
            {
                node.Center = Add(node.Center, key, value, keyIndex + 1);
            }
            else if (key[keyIndex] < node.Char)
            {
                node.Left = Add(node.Left, key, value, keyIndex + 1);
            }
            else
            {
                node.Right = Add(node.Right, key, value, keyIndex + 1);
            }

            return node;
        }

        public T Get(string key)
        {
            var current = root;
            int keyIndex = 0;

            while (current != null)
            {
                if (keyIndex == key.Length - 1)
                {
                    return current.Value;
                }
                else if (key[keyIndex] < current.Char)
                {
                    current = current.Left;
                }
                else if (key[keyIndex] > current.Char)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Center;
                }

                keyIndex++;
            }

            return default(T);
        }

        class Node<T>
        {
            public char Char { get; set; }
            public T Value { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Center { get; set; }
            public Node<T> Right { get; set; }
            
        }
    }
}
