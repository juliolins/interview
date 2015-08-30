using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class UnionFind
    {

        public static void Test()
        {
            UnionFind unionFind = new UnionFind(new string[] { "A", "B", "C", "D", "E", "F" });

            unionFind.Print();

            unionFind.Connect("A", "C");
            unionFind.Print();

            unionFind.Connect("A", "B");
            unionFind.Print();

            unionFind.Connect("D", "A");
            unionFind.Print();

            Console.WriteLine("Largest = " + unionFind.FindLargestInConnectedSet("A"));
            Console.WriteLine();

            unionFind.Connect("F", "E");
            unionFind.Print();

            unionFind.Connect("F", "B");
            unionFind.Print();

            Console.WriteLine("Largest = " + unionFind.FindLargestInConnectedSet("A"));

        }

        private Dictionary<string, string> network = new Dictionary<string, string>();

        private Dictionary<string, int> numberConnected = new Dictionary<string, int>();

        private Dictionary<string, string> largestInSet = new Dictionary<string, string>();


        private int maxConnected = 0;

        public UnionFind(string[] members)
        {
            foreach (string member in members)
            {
                //each member points to itself in the beginning
                network.Add(member, member);
                numberConnected.Add(member, 1);
                largestInSet.Add(member, member);
            }
        }


        public void Print()
        {
            foreach (string key in network.Keys)
            {
                Console.Write(key + " ");
            }
            Console.WriteLine();

            foreach (string key in network.Keys)
            {
                Console.Write(network[key] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("All connected = " + IsAllConnected());
            Console.WriteLine();
        }

        public void Connect(string memberID_1, string memberID_2)
        {
            int height1, height2;
            string root1 = FindRoot(memberID_1, out height1);
            string root2 = FindRoot(memberID_2, out height2);

            //Root(a) = Root(b)
            if (height1 <= height2)
            {
                network[root1] = network[root2];

                numberConnected[root2] += numberConnected[root1];
                maxConnected = Math.Max(maxConnected, numberConnected[root2]);

                largestInSet[root2] = Max(largestInSet[root1], largestInSet[root2]);
            }
            else
            {
                //Root(b) = Root(b)
                network[root2] = network[root1];
                numberConnected[root1] += numberConnected[root2];
                maxConnected = Math.Max(maxConnected, numberConnected[root1]);

                largestInSet[root1] = Max(largestInSet[root1], largestInSet[root2]);
            }
        }

        public string FindLargestInConnectedSet(string memberID)
        {
            int height;
            return largestInSet[FindRoot(memberID, out height)];
        }

        public bool IsConnected(string memberID_1, string memberID_2)
        {
            int height1, height2;
            return FindRoot(memberID_1, out height1) == FindRoot(memberID_2, out height2);
        }

        public bool IsAllConnected()
        {
            return maxConnected == network.Count;
        }

        /// <summary>
        /// Keeps going up until it finds the root.
        /// </summary>
        private string FindRoot(string memberID, out int height)
        {
            height = 0;

            while (memberID != network[memberID])
            {
                height++;
                memberID = network[memberID];
            }

            return memberID;
        }

        private string Max(string a, string b)
        {
            if (a.CompareTo(b) >= 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
