using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.SymbolTables
{
    public class Trie26Test
    {
        public static void Test()
        {
            var trie = new TernarySearchTrie<int>();

            trie.Add("julio", 11);
            trie.Add("cesar", 13);
            trie.Add("dos", 17);
            trie.Add("santos", 19);
            trie.Add("lins", 23);

            Write<int>("julio", trie);
            Write<int>("cesar", trie);
            Write<int>("dos", trie);
            Write<int>("santos", trie);
            Write<int>("lins", trie);
        }

        private static void Write<T>(string key, TernarySearchTrie<T> trie)
        {
            Console.WriteLine(string.Format("{0} = {1}", key, trie.Get(key)));
        }
    }

    public class Trie26<T>
    {
        private const int Alphabet = 26;
        private Node<T> root;

        public Trie26() 
        {
            root = new Node<T>();
        }

        public void Add(string key, T value)
        {
            Add(root, key, value, 0);
        }

        private Node<T> Add(Node<T> node, string key, T Value, int keyIndex)
        {
            if (node == null)
            {
                node = new Node<T>();
            }

            if (keyIndex == key.Length) 
            {
                node.Value = Value;
            } 
            else 
            {
                int nextIndex = key[keyIndex] - 'a';
                node.Next[nextIndex] = Add(node.Next[nextIndex], key, Value, keyIndex + 1);
            }

            return node;
        }

        public T Get(string key)
        {
            int keyIndex = 0;
            Node<T> current = root;

            do
            {
                int nextIndex = key[keyIndex++] - 'a';
                current = current.Next[nextIndex];

                if (keyIndex == key.Length)
                {
                    return current.Value;
                }

            } while (current != null);

            return default(T);
        }

        private class Node<T>
        {
            public Node()
            {
                Next = new Node<T>[Alphabet];
            }

            public T Value { get; set; }
            public Node<T>[] Next { get; private set; }
        }
    }

    
}
