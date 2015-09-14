using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class SameContact
    {
        public static void Test()
        {
            string[][] contacts = new string[][] 
            {
                new string[] {"Gaurav", "gaurav@gmail.com", "gaurav@gfgQA.com"},
                new string[] { "Lucky", "lucky@gmail.com", "+1234567"},
                new string[] { "gaurav123", "+5412312", "gaurav123@skype.com"},
                new string[] { "gaurav1993", "+5412312", "gaurav@gfgQA.com"}
            };

            var result = Analyze(contacts);

            foreach (var item in result)
            {
                item.PrintToConsole(); //my extension method
            }
        }

        public static List<List<int>> Analyze(string[][] contacts)
        {
            bool[] visited = new bool[contacts.Length];
            var graph = BuildGraph(contacts);
            var result = new List<List<int>>();

            for (int i = 0; i < contacts.Length; i++)
            {
                //ignore visited
                if (visited[i]) continue;

                //if i is not visited, create a list and add all connected
                var list = ListConnected(i, graph, visited);

                result.Add(list);
            }

            return result;
        }

        //non-recursive Bfs
        //adds each non-visited node to the list
        private static List<int> ListConnected(int initialNode, Dictionary<int, List<int>> graph, bool[] visited)
        {
            var list = new List<int>();
            var queue = new Queue<int>();
            queue.Enqueue(initialNode);

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                visited[v] = true;
                list.Add(v);

                foreach (var node in graph[v])
                {
                    if (!visited[node])
                    {
                        queue.Enqueue(node);
                    }
                }
            }

            return list;
        }

        public static Dictionary<int, List<int>> BuildGraph(string[][] contacts)
        {
            //inicial graph
            var graph = new Dictionary<int, List<int>>();
            var map = new Dictionary<string, List<int>>();

            //iterate through each contact
            for (int i = 0; i < contacts.Length; i++)
            {
                //add contact to graph
                graph.Add(i, new List<int>());

                //iterate through each field
                for (int j = 0; j < contacts[i].Length; j++)
                {
                    string key = contacts[i][j];

                    if (map.ContainsKey(key))
                    {
                        //if this is a repeat, then add connections to the graph
                        Connect(graph, map[key], i);

                        //then add it to the existing set for the key
                        map[key].Add(i);
                    }
                    else
                    {
                        map.Add(key, new List<int>() { i });
                    }
                }
            }

            return graph;
        }

        private static void Connect(Dictionary<int, List<int>> graph, IEnumerable<int> nodes, int newNode)
        {
            //bidirectional graph: add existing nodes to newNode
            graph[newNode].AddRange(nodes);

            //add newNode to each existing node
            foreach (var node in nodes)
            {
                graph[node].Add(newNode);
            }
        }
    }
}
