using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class TrieAgain
    {
        public static void Test()
        {
            TrieAgain trie = new TrieAgain();

            trie.Add("she");
            trie.Add("shells");
            trie.Add("adabla");
            trie.Add("shelf");
            
            Console.WriteLine(trie.Contains("she"));
            Console.WriteLine(trie.Contains("shells"));
            Console.WriteLine(trie.Contains("adabla"));

            trie.Remove("adabla");
            Console.WriteLine(trie.Contains("adabla"));

            IEnumerable<string> list = trie.List("she");
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }

        }

        private Node root;

        public void Add(string word)
        {
            root = DoAdd(word, 0, root);           
        }

        private Node DoAdd(string word, int index, Node node)
        {
            if (node == null)
            {
                node = new Node();
                node.Letter = word[index];

                //if last char
                if (index == word.Length - 1)
                {
                    node.IsValue = true;
                    return node;
                }
                else
                {
                    node.Center = DoAdd(word, index + 1, node.Center);
                }

            }
            else
            {
                if (word[index] < node.Letter)
                {
                    node.Left = DoAdd(word, index, node.Left);
                }
                else if (word[index] > node.Letter)
                {
                    node.Right = DoAdd(word, index, node.Right);
                } 
                else 
                {
                    node.Center = DoAdd(word, index + 1, node.Center);
                }
            }

            return node;
        }

        public void Remove(string word)
        {
            Node current = root;
            int index = 0;

            while (current != null)
            {
                if (word[index] < current.Letter)
                {
                    current = current.Left;
                }
                else if (word[index] < current.Letter)
                {
                    current = current.Right;
                }
                else
                {
                    //found a match
                    index++;

                    //if end of the word, mark node as removed
                    //could throw an exception here if IsValue is already false
                    if (index == word.Length)
                    {
                        current.IsValue = false;
                        return;
                    }
                    else
                    {
                        current = current.Center;
                    }
                }
            }

        }

        public bool Contains(string word)
        {
            Node node = ContainsNode(word);

            if (node == null)
            {
                return false;
            }
            else
            {
                return node.IsValue;
            }
        }

        private Node ContainsNode(string word)
        {
            Node current = root;
            int index = 0;

            while (current != null)
            {
                if (word[index] < current.Letter)
                {
                    current = current.Left;
                }
                else if (word[index] > current.Letter)
                {
                    current = current.Right;
                }
                else
                {
                    //found a match, increment index
                    index++;

                    //end of word, return current's node value
                    if (index == word.Length)
                    {
                        return current;
                    }
                    else
                    {
                        //not at the end yet, keep going
                        current = current.Center;
                    }
                }
            }

            return null;
        }

        public IEnumerable<string> List(string prefix)
        {
            List<string> list = new List<string>();
           
            //current will point to the node in the tree that is at the end of the prefix
            Node current = ContainsNode(prefix);

            if (current == null)
            {
                return list;
            }

            //Stack<Node> stack = new Stack<Node>();
            //while (stack.Count > 0 && current != null)
            //{
            //    if (current == null)
            //    {
            //    }
            //}

            if (current.IsValue)
            {
                list.Add(prefix);
            }

            DoList(prefix, current.Left, list);
            DoList(prefix, current.Right, list);
            DoList(prefix, current.Center, list);

            return list;
        }

        private void DoList(string prefix, Node node, List<string> list)
        {
            if (node == null)
            {
                return;
            }

            if (node.IsValue)
            {
                list.Add(prefix + node.Letter);
            }

            DoList(prefix, node.Left, list);
            DoList(prefix, node.Right, list);
            DoList(prefix + node.Letter, node.Center, list);
        }


        class Node
        {
            public char Letter;
            public bool IsValue;

            public Node Left;
            public Node Right;
            public Node Center;
        }
    }
}
