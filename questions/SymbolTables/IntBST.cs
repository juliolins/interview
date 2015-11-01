using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.SymbolTables
{
    public static class IntBSTTest
    {
        public static void Test()
        {
            var bst = new IntBST(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9});
        }
    }


    public class IntBST
    {
        private Node root;

        public IntBST()
        {

        }

        public IntBST(int[] array)
        {
            Insert(array, 0, array.Length - 1);    
        }

        private void Insert(int[] array, int start, int end) 
        {
            if (start > end) return;

            int middle = (start + end) / 2;
            Add(array[middle]);
            Insert(array, start, middle - 1);
            Insert(array, middle + 1, end);
        }

        public void Add(int x)
        {
            root = Add(root, x);
        }

        private Node Add(Node node, int x)
        {
            if (node == null) return new Node() { Value = x };

            if (x < node.Value)
            {
                node.Left = Add(node.Left, x);
            }
            else if (x > node.Value)
            {
                node.Right = Add(node.Right, x);
            }
            else
            {
                node.Value = x;
            }

            return node;
        }

        private class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }
}
