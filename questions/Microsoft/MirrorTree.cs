using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Microsoft
{
    public class MirrorTree
    {
        private Node root;

        public void Add(int value)
        {

        }

        public void Mirror()
        {
            root = Mirror(root);
        }

        private Node Mirror(Node node)
        {
            if (node == null)
            {
                return null;
            }

            Node left = Mirror(node.Left);
            Node right = Mirror(node.Right);

            node.Right = left;
            node.Left = right;

            return node;
        }

        class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }

}
