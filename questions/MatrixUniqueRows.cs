using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class MatrixUniqueRows
    {

        public static void Test()
        {
            MatrixTrie trie = new MatrixTrie();

            trie.Put(new int[] { 1, 0, 1 });
            trie.Put(new int[] { 1, 0, 0 });
            trie.Put(new int[] { 1, 1, 1 });
            trie.Put(new int[] { 0, 0, 0 });
        }


        public static void PrintUniqueRows(int[][] matrix)
        {
            MatrixTrie trie = new MatrixTrie();

            for (int i = 0; i < matrix.Length; i++)
            {
                if (!trie.Contains(matrix[i])) 
                {
                    Console.WriteLine(matrix[i]);
                    trie.Put(matrix[i]);
                }
            }
        }
    }

    public class MatrixTrie
    {
        private TrieNode root;

        public void Put(int[] value)
        {
            root = DoAdd(root, value, 0);
        }

        //adds a value into a unbalanced tree
        //return true if its a new node
        private bool AddX(int[] value)
        {
            int valueIndex = 0;

            //root is null, use first element
            if (root == null && valueIndex < value.Length)
            {
                root = new TrieNode(value[valueIndex]);
            }

            TrieNode current = root;

            while (valueIndex < value.Length)
            {
                if (current.Value > value[valueIndex])
                {
                    if (current.Left == null)
                    {
                        //add new left node
                        current.Left = new TrieNode(value[valueIndex]);
                        valueIndex++;
                    }

                    current = current.Left;
                }
                else if (current.Value < value[valueIndex])
                {
                    if (current.Right == null)
                    {
                        //add new right node
                        current.Right = new TrieNode(value[valueIndex]);
                        valueIndex++;
                    }

                    current = current.Right;

                }
                else
                {
                    //same value, consume lement
                    valueIndex++;

                    //if this was the last element and it was center, then the value already existed
                    if (valueIndex >= value.Length)
                    {
                        return true;
                    }

                    //move center or create
                    if (current.Center == null)
                    {
                        current.Center = new TrieNode(value[valueIndex]);
                    }

                    current = current.Center;
                }
            }

            return false;               
        }

        public bool Contains(int[] value)
        {
            int valueIndex = 0;
            TrieNode current = root;

            while (current != null)
            {
                if (value[valueIndex] < current.Value)
                {
                    current = current.Left;
                }
                else if (value[valueIndex] > current.Value)
                {
                    current = current.Right;
                }
                else
                {
                    //equals
                    valueIndex++;

                    if (valueIndex == value.Length)
                    {
                        return true;
                    }

                    current = current.Center;
                }
            }

            return false;
        }

        private TrieNode DoAdd(TrieNode node, int[] value, int valueIndex)
        {
            if (valueIndex >= value.Length)
            {
                return null;
            }

            if (node == null)
            {
                node = new TrieNode(value[valueIndex]);
            }

            if (value[valueIndex] < node.Value)
            {
                node.Left = DoAdd(node.Left, value, valueIndex);
            }
            else if (value[valueIndex] > node.Value)
            {
                node.Right = DoAdd(node.Right, value, valueIndex);
            }
            else
            {
                node.Center = DoAdd(node.Center, value, valueIndex + 1);
            }

            return node;
        }

        class TrieNode
        {
            public int Value { get; set; }
            public TrieNode Left { get; set; }
            public TrieNode Right { get; set; }
            public TrieNode Center { get; set; }

            public TrieNode(int value)
            {
                this.Value = value;
            }
        }
    }

    
}
