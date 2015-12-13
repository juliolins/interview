using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.CrackingTough
{
    public class Strings
    {
        public static void Test()
        {
            string text = "Video provides a powerful way to help you prove your point. When you click Online Video, you can paste in the embed code for the video you want to add. You can also type a keyword to search online for the video that best fits your document. To make your document look professionally produced, Word provides header, footer, cover page, and text box designs that complement each other. For example, you can add a matching cover page, header, and sidebar. Click Insert and then choose the elements you want from the different galleries. Themes and styles also help keep your document coordinated. When you click Design and choose a new Theme, the pictures, charts, and SmartArt graphics change to match your new theme. When you apply styles, your headings change to match the new theme. Save time in Word with new buttons that show up where you need them.";
            //string text = "powerful way to help you prove your point";

            //StringReader reader = new StringReader(text);
            //Console.WriteLine(CalculateDistance(reader, "you", "new"));

            FindIndexes (text, new string[] { "a", "way", "your" }).PrintToConsole();
            FindIndexes2(text, new string[] { "a", "way", "your" }).PrintToConsole();


        //    var trie = new ValueTrie<int>(-1);
        //    trie.Add("shell", 1);
        //    trie.Add("seashells", 2);
        //    trie.Add("shesells", 3);

        //    Console.WriteLine(trie.Get("she"));
        //    Console.WriteLine(trie.Get("shells"));
        //    Console.WriteLine(trie.Get("shell"));
        }


        public static int CalculateDistance(TextReader reader, string wordA, string wordB)
        {
            var dictionary = GetPositions(reader);

            if (!dictionary.ContainsKey(wordA) || !dictionary.ContainsKey(wordB))
            {
                return -1;
            }

            var iteratorA = dictionary[wordA].GetEnumerator();
            var iteratorB = dictionary[wordB].GetEnumerator();

            if (!iteratorA.MoveNext()) return -1;
            if (!iteratorB.MoveNext()) return -1;

            int minDistance = int.MaxValue;

            while (true)
            {
                int positionA = iteratorA.Current;
                int positionB = iteratorB.Current;

                minDistance = Math.Min(minDistance, Math.Abs(positionA - positionB));

                if (positionA < positionB)
                {
                    if (!iteratorA.MoveNext()) return minDistance;
                }
                else
                {
                    if (!iteratorB.MoveNext()) return minDistance;
                }
            }
        }

        private static IDictionary<string, IList<int>> GetPositions(TextReader reader)
        {
            var dictionary = new Dictionary<string, IList<int>>();
            int position = 1;
            string line = null;

            while ((line = reader.ReadLine()) != null)
            {
                foreach (var word in line.Split(' '))
                {
                    AddPosition(dictionary, word, position++);
                }
            }

            return dictionary;
        }

        private static void AddPosition(IDictionary<string, IList<int>> dictionary, string word, int position)
        {
            if (!dictionary.ContainsKey(word))
            {
                dictionary.Add(word, new List<int>());
            }

            dictionary[word].Add(position);
        }

        public static int[] FindIndexes(string text, string[] words)
        {
            int mainIndex = 0;
            int[] indexes = new int[words.Length];
            int[] results = new int[words.Length];

            while (mainIndex < text.Length)
            {
                //check each index in the words
                for (int j = 0; j < words.Length; j++)
                {
                    if (indexes[j] < words[j].Length)
                    {
                        if (words[j][indexes[j]] == text[mainIndex])
                        {
                            indexes[j]++;
                        }
                        else
                        {
                            indexes[j] = 0;
                        }
                    }
                    else if (results[j] == 0)
                    {
                        results[j] = mainIndex - words[j].Length;
                    }
                }

                mainIndex++;
            }

            return results;
        }

        public static IEnumerable<int> FindIndexes2(string text, string[] words)
        {
            var trie = new ValueTrie<int>(-1);
            for (int i = text.Length - 1; i >= 0; i--)
            {
                trie.Add(text.Substring(i), i);
            }

            return words.Select(word => trie.Get(word));
        }
    }


    internal class ValueTrie<T> where T : struct
    {
        private readonly T NoValue;
        private Node root;

        public ValueTrie(T NoValue)
        {
            this.NoValue = NoValue;
        }

        internal void Add(string text)
        {
            root = Add(text, 0, root, NoValue);
        }

        internal void Add(string text, T value)
        {
            root = Add(text, 0, root, value);
        }

        private Node Add(string text, int index, Node node, T value)
        {
            if (index >= text.Length) return null;

            if (node == null)
            {
                node = new Node() { Char = text[index] };

                if (index == text.Length - 1)
                {
                    node.Value = value;
                    return node;
                }
            }

            if (text[index] == node.Char)
            {
                node.Center = Add(text, index + 1, node.Center, value);
            }
            else if (text[index] < node.Char)
            {
                node.Left = Add(text, index, node.Left, value);
            }
            else
            {
                node.Right = Add(text, index, node.Right, value);
            }

            return node;
        }

        internal T Get(string text)
        {
            var current = root;
            int index = 0;

            while (current != null && index < text.Length)
            {
                if (text[index] == current.Char)
                {
                    index++;
                    if (index == text.Length) return current.Value.HasValue ? current.Value.Value : GetValue(current.Center);
                    else current = current.Center;
                }
                else if (text[index] < current.Char)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return NoValue;
        }

        private T GetValue(Node node)
        {
            var stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (current.Value.HasValue) return current.Value.Value;

                if (current.Right != null) stack.Push(current.Right);
                if (current.Center != null) stack.Push(current.Center);
                if (current.Left != null) stack.Push(current.Left);
            }

            return NoValue;
        }

        class Node
        {
            internal Node Left { get; set; }
            internal Node Right { get; set; }
            internal Node Center { get; set; }
            internal char Char { get; set; }
            internal T? Value { get; set; }
        }
    }
}
