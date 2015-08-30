using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{

    public class GraphTest
    {
        public static void Test()
        {
            Graph graph = new Graph(10);

            graph.Connect(0, 2);
            graph.Connect(0, 1);
            graph.Connect(2, 4);
            graph.Connect(3, 4);
            graph.Connect(3, 5);
            graph.Connect(4, 5);
            graph.Connect(4, 6);
            graph.Connect(6, 8);

            GraphHandler handler = new BFS_EdgeTo(graph.Clone());

            handler.Path(0, 8).PrintToConsole();
        }
    }

    public class Graph
    {
        private readonly int vertices;
        private List<int>[] edges;

        public Graph(int size)
        {
            this.vertices = size;
            edges = new List<int>[size];

            //initialize the edge lists
            for (int i = 0; i < size; i++)
            {
                edges[i] = new List<int>();
            }
        }

        public void Connect(int v, int w)
        {
            edges[v].Add(w);
            edges[w].Add(v);
        }

        public IEnumerable<int> Adjecents(int v)
        {
            return edges[v];
        }

        public int VerticeNumber
        {
            get { return vertices; }
        }

        public Graph Clone()
        {
            List<int>[] newEdges = new List<int>[vertices];

            for (int v = 0; v < vertices; v++)
            {
                //create list of edges for that vertice
                newEdges[v] = new List<int>();

                //add replicated edges
                foreach (int w in edges[v])
                {
                    newEdges[v].Add(w);
                }
            }

            Graph clone = new Graph(vertices);
            clone.edges = newEdges;
            return clone;
        }
    }

    public interface GraphHandler
    {
        IEnumerable<int> Path(int v, int w);
    }


    public class DFS_EdgeTo : GraphHandler
    {
        private Graph graph;

        public DFS_EdgeTo(Graph graph)
        {
            this.graph = graph;
        }

        public IEnumerable<int> Path(int v, int w)
        {         
            bool[] visited = new bool[graph.VerticeNumber];
            int[] edgeTo = new int[graph.VerticeNumber];

            List<int> path = new List<int>();

            if (DoDFS(v, w, edgeTo, visited))
            {

                while (w != v)
                {
                    path.Add(w);
                    w = edgeTo[w];
                }

                path.Add(v);
            }

            return path;
        }

        private bool DoDFS(int start, int w, int[] edgeTo, bool[] visited)
        {
            foreach (int v in graph.Adjecents(start))
            {
                if (visited[v]) continue;

                //mark v as visited
                visited[v] = true;

                //mark the path
                edgeTo[v] = start;

                if (v == w)
                {
                    return true;
                }

                //keep checking the path, now starting from v
                if (DoDFS(v, w, edgeTo, visited))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class BFS_EdgeTo : GraphHandler
    {
        private Graph graph;

        public BFS_EdgeTo(Graph graph)
        {
            this.graph = graph;
        }

        public IEnumerable<int> Path(int v, int w)
        {
            bool[] visited = new bool[graph.VerticeNumber];
            int[] edgeTo = new int[graph.VerticeNumber];

            List<int> path = new List<int>();

            if (DoBFS(v, w, edgeTo, visited))
            {

                while (w != v)
                {
                    path.Add(w);
                    w = edgeTo[w];
                }

                path.Add(v);
            }

            return path;
        }

        private bool DoBFS(int start, int w, int[] edgeTo, bool[] visited)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();

                //mark v as visited
                visited[v] = true;

                if (v == w)
                {
                    return true;
                }

                //otherwise, keep adding adjacents
                foreach (int adj in graph.Adjecents(v))
                {
                    if (!visited[adj])
                    {
                        edgeTo[adj] = v;
                        queue.Enqueue(adj);
                    }
                }
            }

            return false;
        }
    }


    public class DFS_Stack : GraphHandler
    {
        private Graph graph;

        public DFS_Stack(Graph graph)
        {
            this.graph = graph;
        }

        public IEnumerable<int> Path(int v, int w)
        {
            bool[] visited = new bool[graph.VerticeNumber];
            Stack<int> path = new Stack<int>();

            path.Push(v);
            if (!DoDFS(v, w, path, visited))
            {
                path.Pop();
            }

            return path;
        }

        private bool DoDFS(int start, int w, Stack<int> path, bool[] visited)
        {
            
            foreach (int v in graph.Adjecents(start))
            {
                if (visited[v]) continue;

                //mark v as visited
                visited[v] = true;

                //found the destination
                if (v == w)
                {
                    path.Push(v);
                    return true;
                }
                
                //add v to this path
                path.Push(v);

                //keep checking the path, now starting from v
                if (DoDFS(v, w, path, visited))
                {
                    return true;
                }
                else
                {
                    //if not found, remove v from stack
                    path.Pop();
                }
            }

            return false;
        }

    }
}
