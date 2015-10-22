using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{

    public class SocialNetworkTest
    {
        public static void Test()
        {
            SocialNetwork sn = new SocialNetwork(10);

            sn.Connect(1, 2);
            sn.Connect(6, 2);
            sn.Connect(9, 2);

            sn.Connect(3, 4);
            sn.Connect(7, 8);
            sn.Connect(4, 7);

            sn.Connect(3, 2);

            Console.WriteLine(sn.FindLargest(1));
            Console.WriteLine(sn.FindLargest(8));
            Console.WriteLine(sn.FindLargest(6));
            Console.WriteLine(sn.FindLargest(9));
        }
    }



    public class SocialNetwork
    {
        private int[] network;


        public SocialNetwork(int size)
        {
            network = new int[size];

            for (int i = 0; i < size; i++)
            {
                network[i] = i;
            }
        }

        public void Connect(int a, int b)
        {
            int rootA = FindRoot(a);
            int rootB = FindRoot(b);

            if (rootA > rootB)
            {
                network[rootB] = rootA;
            }
            else
            {
                network[rootA] = rootB;
            }

        }

        public int FindLargest(int a)
        {
            return FindRoot(a);
        }

        private int FindRoot(int i)
        {
            while (network[i] != i)
            {
                i = network[i];
            }

            return i;
        }

        public bool IsAllConnected()
        {
            int root = network[0];

            for (int i = 1; i < network.Length; i++)
            {
                if (network[i] != root) return false;
            }

            return true;
        }
    }
}
