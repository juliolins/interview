using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class TrieTest
    {
        public static void Test()
        {
            Trie trie = new Trie();

            trie.Put("shells", 1);
            trie.Put("sold", 1);
            trie.Put("the", 1);
            trie.Put("buy", 1);
            trie.Put("shore", 1);
            trie.Put("128", 1);
            trie.Put("128.192", 1);
            trie.Put("128.192.136", 1);
            trie.Put("128.192.136.295", 1);

            Console.WriteLine("Done");

            IList<string> words = trie.ToList();

            foreach (string item in words)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("trie.Contains(buy) = " + trie.Contains("buy"));
            Console.WriteLine("trie.Contains(shore) = " + trie.Contains("shore"));
            Console.WriteLine("trie.Contains(shel) = " + trie.Contains("shel"));

            Console.WriteLine("Prefix:");
            foreach (string item in trie.MatchPrefix("sh"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Prefix of 128.192.136.295");
            foreach (string item in trie.PrefixesOf("128.192.136.295"))
            {
                Console.WriteLine(item);
            }

        }
    }


    public class Trie
    {
        private TrieNode root;

        public void Put(string word, int value)
        {
            root = DoPut(word, value, root, 0);
        }

        public IList<string> ToList()
        {
            IList<string> list = new List<string>();

            if (root != null) Collect(root, list, new List<char>(), "");

            return list;
        }

        private void Collect(TrieNode node, IList<string> words, List<char> chars, string prefix)
        {
            //if this node has a value, we have a word
            if (node.Value != null)
            {
                chars.Add(node.Letter);
                words.Add(prefix + new string(chars.ToArray()));
                chars.RemoveAt(chars.Count - 1);
            }

            //first go left
            if (node.Left != null) Collect(node.Left, words, chars, prefix);

            //then go center
            if (node.Center != null)
            {
                //add current char do the end of list
                chars.Add(node.Letter);

                //go center 
                Collect(node.Center, words, chars, prefix);

                //remove last element
                chars.RemoveAt(chars.Count - 1);
            }

            //then go right
            if (node.Right != null) Collect(node.Right, words, chars, prefix);

        }


        public IList<string> PrefixesOf(string longWord)
        {
            IList<string> list = new List<string>();

            if (root != null) DoPrefixesOf(root, list, new List<char>(), longWord, 0);

            return list;
        }

        private void DoPrefixesOf(TrieNode node, IList<string> words, List<char> chars, string longWord, int position)
        {
            //word cannot be longer than longWord
            if (position == longWord.Length - 1)
            {
                return;
            }

            //if this node has a value, we have a word
            if (node.Value != null)
            {
                chars.Add(node.Letter);
                words.Add(new string(chars.ToArray()));
                chars.RemoveAt(chars.Count - 1);
            }

            //first go left
            if (node.Left != null) DoPrefixesOf(node.Left, words, chars, longWord, position);

            //then go center
            if (node.Center != null && node.Letter == longWord[position])
            {
                //add current char do the end of list
                chars.Add(node.Letter);

                //go center 
                DoPrefixesOf(node.Center, words, chars, longWord, position + 1);

                //remove last element
                chars.RemoveAt(chars.Count - 1);
            }

            //then go right
            if (node.Right != null) DoPrefixesOf(node.Right, words, chars, longWord, position);

        }

        public IList<string> MatchPrefix(string prefix)
        {
            List<string> words = new List<string>();
            TrieNode current = root;
            int position = 0;

            while (current != null && position < prefix.Length)
            {
                if (current.Letter < prefix[position])
                {
                    current = current.Right;
                }
                else if (current.Letter > prefix[position])
                {
                    current = current.Left;
                }
                else
                {
                    //char match
                    if (position == prefix.Length - 1)
                    {
                        Collect(current.Center, words, new List<char>(), prefix);
                        break;
                    }
                    else
                    {
                        current = current.Center;
                        position++;
                    }
                }
            }

            return words;
        }

        public bool Contains(string word)
        {
            TrieNode current = root;
            int position = 0;


            while (current != null && position < word.Length)
            {
                if (current.Letter < word[position])
                {
                    current = current.Right;
                }
                else if (current.Letter > word[position])
                {
                    current = current.Left;
                }
                else
                {
                    //char match
                    if (position == word.Length - 1)
                    {
                        //no more chars to match, return true if node has a value
                        return current.Value != null;
                    }
                    else
                    {
                        current = current.Center;
                        position++;
                    }
                }
            }

            return false;
        }

        private TrieNode DoPut(string word, int value, TrieNode node, int position)
        {
            if (position == word.Length)
            {
                return null;
            }

            if (node == null)
            {
                node = new TrieNode(word[position]);
                node.Center = DoPut(word, value, node.Center, position  + 1);
            }
            else if (node.Letter < word[position])
            {
                node.Right = DoPut(word, value, node.Right, position);
            }
            else if (node.Letter > word[position])
            {
                node.Left = DoPut(word, value, node.Left, position);
            }
            else
            {
                node.Center = DoPut(word, value, node.Center, position + 1);
            }
            
            //if this was the last char, set value
            if (position == word.Length - 1) 
            {
                node.Value = value;
            }

            return node;
        }
    }

    class TrieNode
    {
        public Nullable<int> Value { get; set; }
        public char Letter { get; set; }

        public TrieNode Left { get; set; }
        public TrieNode Right { get; set; }
        public TrieNode Center { get; set; }

        public TrieNode(char letter)
        {
            this.Letter = letter;
        }
    }
}

