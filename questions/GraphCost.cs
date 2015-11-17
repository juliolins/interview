using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class TestGraph
    {
        public static void Test()
        {
            IDirectedGraph graph = new SetGraph(10);


            graph.Connect(0, 2, 5);
            graph.Connect(2, 4, 5);
            graph.Connect(4, 6, 5);

            graph.Connect(0, 1, 1);
            graph.Connect(1, 3, 1);
            graph.Connect(3, 9, 1);
            graph.Connect(9, 7, 1);
            graph.Connect(7, 6, 1);

            DFSCost dfs = new DFSCost(graph, 0);

            Console.WriteLine(dfs.GetShortestPath(6).Print());
        }
    }

    public interface IDirectedGraph
    {
        int Size {get;}

        void Connect(int v, int w, int cost);

        bool IsConnected(int v, int w);

        int GetCost(int v, int w);

        IEnumerable<int> GetAdjacents(int v);
    }

    public class SetGraph : IDirectedGraph
    {
        private int size;
        private IDictionary<int, int>[] connections;

        public SetGraph(int size)
        {
            this.size = size;
            connections = new IDictionary<int, int>[size];

            for (int i = 0; i < size; i++)
            {
                connections[i] = new Dictionary<int, int>();
            }
        }

        public int Size
        {
            get { return this.size; }
        }

        public void Connect(int v, int w, int cost)
        {
            connections[v].Add(w, cost);
        }

        public bool IsConnected(int v, int w)
        {
            return connections[v].ContainsKey(w);
        }

        public int GetCost(int v, int w)
        {
            return connections[v][w];
        }

        public IEnumerable<int> GetAdjacents(int v)
        {
            return connections[v].Keys;
        }
    }

    public class DFSCost
    {
        private bool[] visited;
        private IDirectedGraph graph;
        private int start;
        private Dictionary<int, IEnumerable<int>> paths;

        public DFSCost(IDirectedGraph graph, int start)
        {
            this.graph = graph;
            this.start = start;

            this.visited = new bool[graph.Size];
            paths = new Dictionary<int, IEnumerable<int>>();
        }

        public IEnumerable<int> GetShortestPath(int dest)
        {
            DFS(start, dest, new Stack<int>(), 0);

            return paths[paths.Keys.Min()];
        }

        private void DFS(int v, int dest, Stack<int> stack, int cost)
        {
            stack.Push(v);
            visited[v] = true;

            if (v == dest)
            {
                visited[dest] = false;//let other paths arrive at destination
                paths.Add(cost, stack.ToList().Reverse<int>());
            }
            else
            {
                foreach (int w in graph.GetAdjacents(v))
                {
                    if (!visited[w])
                    {
                        DFS(w, dest, stack, cost + graph.GetCost(v, w));
                    }
                }
            }

            stack.Pop();
        }
    }

    public static class PrintExtension
    {

        public static void PrintToConsole<T>(this IEnumerable<T> enumerable, bool withCount = false)
        {
            if (withCount) Console.Write(string.Format("[{0}] ", enumerable.Count()));
            Console.WriteLine(Print(enumerable));
        }

        public static string Print<T>(this IEnumerable<T> enumerable)
        {
            StringBuilder builder = new StringBuilder(128);
            bool empty = true;

            builder.Append('{');

            foreach (T item in enumerable)
            {
                empty = false;

                builder.Append(item.ToString());
                builder.Append(',');
                builder.Append(' ');
            }

            if (!empty) builder.Remove(builder.Length - 2, 2);
            builder.Append('}');

            return builder.ToString();
        }

    }
}
