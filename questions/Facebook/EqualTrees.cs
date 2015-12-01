using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Facebook
{
    public class EqualTrees
    {

        /// <summary>
        /// NEW: Using edge-to idea
        /// </summary>
        private Node Find(Node rootA, Node rootB, Node x)
        {
            var indexMap = new Dictionary<Node, int>();
            var parentMap = new Dictionary<Node, Node>();
            var navStack = new Stack<Node>();

            //find X and build map 
            //Edge to: how we got to each node (parent and child index)
            navStack.Push(rootA);
            while (navStack.Any())
            {
                var current = navStack.Pop();

                if (current == x) 
                {
                    break;
                }

                for (int i = 0; i < current.Children.Length; i++)
                {
                    navStack.Push(current.Children[i]);
                    indexMap.Add(current.Children[i], i);
                    parentMap.Add(current.Children[i], current);
                }
            }

            //build path from maps
            var path = new Stack<int>();
            var currentPath = x;
            while (currentPath != rootA)
            {
                path.Push(indexMap[currentPath]);
                currentPath = parentMap[currentPath];
            }
            
            //apply path to 2nd tree
            var currentB = rootB;
            foreach (int i in path)
            {
                currentB = currentB.Children[i];
            }

            return currentB;
        }


        class Node
        {
            public Node[] Children { get; set; }
        }
    }
}
