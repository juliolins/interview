using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    /*
    Input:  Dictionary = {POON, PLEE, SAME, POIE, PLEA, PLIE, POIN}
                 start = TOON
                 target = PLEA
    Output: 7
    Explanation: TOON - POON - POIN - POIE - PLIE - PLEE - PLEA
    */
    //http://www.geeksforgeeks.org/length-of-shortest-chain-to-reach-a-target-word/
    public class WordTransition
    {

        public static void Test()
        {
            string[] dictionary = { "POON", "PLEE", "SAME", "POIE", "PLEA", "PLIE", "POIN" };

            Console.WriteLine(GetLength(dictionary, "TOON", "PLEA"));
        }

        public static int GetLength(string[] dictionary, string start, string end)
        {
            var visited = new Dictionary<string, bool>();
            var graph = BuildGraph(dictionary, start);

            //bfs
            var queue = new Queue<QueueElement>();
            queue.Enqueue(new QueueElement() { Word = start, PathLength = 1 });

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                Visit(visited, v.Word);

                if (v.Word.Equals(end))
                {
                    return v.PathLength;
                }
                else
                {
                    for (int i = 0; i < dictionary.Length; i++)
                    {
                        if (IsTransition(v.Word, dictionary[i]) && !IsVisited(visited, dictionary[i]))
                        {
                            queue.Enqueue(new QueueElement() { Word = dictionary[i], PathLength = v.PathLength + 1 });
                        }
                    }
                }
            }

            return -1;
        }

        private static bool IsVisited(Dictionary<string, bool> visited, string word)
        {
            return visited.ContainsKey(word) && visited[word] == true;
        }

        private static void Visit(Dictionary<string, bool> visited, string word)
        {
            if (!visited.ContainsKey(word))
            {
                visited.Add(word, true);
            }
            else
            {
                visited[word] = true;
            }
        }

        public static int GetLength0(string[] dictionary, string start, string end)
        {
            bool[] visited = new bool[dictionary.Length];
            var graph = BuildGraph(dictionary, start);
            
            //bfs
            var queue = new Queue<QueueElement>();
            queue.Enqueue(new QueueElement() { Word = start, PathLength = 1 });

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();

                if (v.Word.Equals(end))
                {
                    return v.PathLength;
                }
                else
                {
                    foreach (var neighbor in graph[v.Word])
                    {
                        queue.Enqueue(new QueueElement() { Word = neighbor, PathLength = v.PathLength + 1 });
                    }
                }
            }

            return -1;
        }



        private static Dictionary<string, List<string>> BuildGraph(string[] dictionary, string start)
        {
            var graph = new Dictionary<string, List<string>>();
            graph.Add(start, new List<string>());
            
            //add transitions from start
            for (int i = 0; i < dictionary.Length; i++)
            {
                if (IsTransition(start, dictionary[i]))
                {
                    graph[start].Add(dictionary[i]);
                }
            }

            //add transitions for words in the dictionary
            for (int i = 0; i < dictionary.Length; i++)
            {
                graph.Add(dictionary[i], new List<string>());

                for (int j = 0; j < dictionary.Length; j++)
                {
                    if (IsTransition(dictionary[i], dictionary[j]))
                    {
                        graph[dictionary[i]].Add(dictionary[j]);
                    }
                }
            }

            return graph;
        }

        private static bool IsTransition(string current, string next)
        {
            int countDifferent = 0;
            for (int i = 0; i < current.Length; i++)
            {
                if (current[i] - next[i] != 0)
                {
                    countDifferent++;
                }
            }

            return countDifferent == 1;
        }

        class QueueElement
        {
            public string Word { get; set; }
            public int PathLength { get; set; }
        }
    }
}
