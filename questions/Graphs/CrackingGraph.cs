using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Graphs
{

    public class TestCrackingGraph
    {
        public static void Test()
        {
            var graph = new CrackingDirectedGraph(10);


            graph.Connect(1, 2);
            graph.Connect(3, 4);
            graph.Connect(5, 3);
            graph.Connect(3, 8);
            graph.Connect(8, 9);
            graph.Connect(2, 5);

            Console.WriteLine(graph.HasPath(1, 9));
            Console.WriteLine(!graph.HasPath(4, 9));
        }
    }

    public class CrackingDirectedGraph
    {
        private List<int>[] vertices;

        public CrackingDirectedGraph(int size)
        {
            vertices = new List<int>[size];

            for (int i = 0; i < size; i++)
            {
                vertices[i] = new List<int>();
            }
        }

        public void Connect(int v, int w)
        {
            vertices[v].Add(w);
        }

        public IEnumerable<int> Adjacents(int v)
        {
            return vertices[v];
        }

        public int Size
        {
            get { return vertices.Length; }
        }
    }

    public static class CrackingHasPath
    {

        public static bool HasPath(this CrackingDirectedGraph graph, int v, int w)
        {
            var queue = new Queue<int>();
            var visited = new bool[graph.Size];

            queue.Enqueue(v);

            while (queue.Count > 0)
            {
                int x = queue.Dequeue();
                visited[x] = true;

                if (x == w)
                {
                    return true;
                }

                foreach (var adj in graph.Adjacents(x))
                {
                    if (!visited[adj]) queue.Enqueue(adj);
                }
            }

            return false;
        }
    }
}
