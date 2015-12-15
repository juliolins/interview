using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.CrackingTough
{
    public class WordDistance
    {
        public static void Test()
        {
            HashSet<string> words = new HashSet<string>() { "DAMP", "LAMP", "LIMP", "LIME", "LIKE", "KITE", "BITE", "BLOB", "CLOG", "PLOT", "PLOB"};

            FindPath("DAMP", "LIKE", words).PrintToConsole();
        }

        public static IEnumerable<String> FindPath(string start, string end, HashSet<string> words)
        {
            //build graph in O(N^2)
            var graph = BuildGraph(words);
            
            //bfs in O(V+E)
            var edgeTo = BuildEdgeTo(graph, start, end);

            //build a stack with path going from end to start
            var path = new Stack<string>();
            string word = end;
            while (!word.Equals(start))
            {
                path.Push(word);

                if (!edgeTo.ContainsKey(word))
                {
                    path.Clear();
                    break;
                }

                word = edgeTo[word];
            }

            path.Push(start);
            return path;
        }

        private static Dictionary<string, string> BuildEdgeTo(Dictionary<string, List<string>> graph, string start, string end)
        {
            //bfs in O(V+E)
            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            queue.Enqueue(start);
            visited.Add(start);

            //maintains path
            var edgeTo = new Dictionary<string, string>();

            while (queue.Count > 0)
            {
                var word = queue.Dequeue();

                //iterate over edges
                foreach (var other in graph[word])
                {
                    if (!visited.Contains(other))
                    {
                        visited.Add(other);
                        edgeTo.Add(other, word);
                        queue.Enqueue(other);
                    }

                    if (other.Equals(end))
                    {
                        return edgeTo;
                    }
                }
            }

            return edgeTo;
        }

        private static Dictionary<string, List<string>> BuildGraph(HashSet<string> words)
        {
            var array = words.ToArray();
            var graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (IsDistanceOne(array[i], array[j]))
                    {
                        AddConnectinon(graph, array[i], array[j]);
                    }                    
                }
            }

            return graph;
        }

        private static void AddConnectinon(Dictionary<string, List<string>> graph, string a, string b)
        {
            if (!graph.ContainsKey(a))
            {
                graph.Add(a, new List<string>());
            }

            if (!graph.ContainsKey(b))
            {
                graph.Add(b, new List<string>());
            }

            graph[a].Add(b);
            graph[b].Add(a);
        }

        private static bool IsDistanceOne(string a, string b)
        {
            if (a.Length != b.Length) return false;

            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) count++;
            }

            return count == 1;
        }
    }
}
