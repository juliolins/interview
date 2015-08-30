using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class TreeAgain 
    {
        public static void Test()
        {
            TreeAgain tree = new TreeAgain();

            //tree.Add(7);
            //tree.Add(3);
            //tree.Add(4);
            //tree.Add(8);
            //tree.Add(6);
            //tree.Add(1);
            //tree.Add(5);
            //tree.Add(2);
            //tree.Add(9);
            //tree.Add(10);
            //tree.Add(11);
            //tree.Add(12);
            //tree.Add(13);
            //tree.Add(14);

            tree.Add(3);
            tree.Add(5);
            tree.Add(7);
            tree.Add(9);

            TreeAgainIterator iterator = tree.GetIterator();

            while (iterator.HasNex())
            {
                Console.Write(iterator.Next() + " ");
                Console.WriteLine();
            }
        }

        private TreeAgainNode root;

        public void Add(int x)
        {
            root = DoAdd(root, x);
        }

        private TreeAgainNode DoAdd(TreeAgainNode node, int x)
        {
            if (node == null)
            {
                node = new TreeAgainNode(x);
                return node;
            }

            if (x < node.Data)
            {
                node.Left = DoAdd(node.Left, x);
            }
            else
            {
                node.Right = DoAdd(node.Right, x);
            }

            return CheckBalance(node);
        }

        public TreeAgainIterator GetIterator()
        {
            return new TreeAgainIterator(root);
        }

        private TreeAgainNode CheckBalance(TreeAgainNode node)
        {
            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                node = FlipColor(node);
            }

            return node;
        }
       
        private TreeAgainNode RotateLeft(TreeAgainNode node)
        {
            TreeAgainNode old = node;
            node = node.Right;
            node.Color = old.Color;

            old.Right = node.Left;
            node.Left = old;
            old.Color = TreeAgainNodeColor.Red;

            return node;
        }

        private TreeAgainNode RotateRight(TreeAgainNode node)
        {
            TreeAgainNode old = node;
            node = node.Left;
            node.Color = old.Color;
            old.Left = node.Right;
            node.Right = old;
            old.Color = TreeAgainNodeColor.Red;

            return node;
        }

        private TreeAgainNode FlipColor(TreeAgainNode node)
        {
            node.Color = TreeAgainNodeColor.Red;
            node.Left.Color = TreeAgainNodeColor.Black;
            node.Right.Color = TreeAgainNodeColor.Black;

            return node;
        }

        private bool IsRed(TreeAgainNode node)
        {
            return (node != null && node.Color == TreeAgainNodeColor.Red);            
        }
    }

    public class TreeAgainIterator
    {
        private Stack<TreeAgainNode> stack;

        public TreeAgainIterator(TreeAgainNode root)
        {
            stack = new Stack<TreeAgainNode>();
            FindNext(root);
        }

        private void FindNext(TreeAgainNode node)
        {
            if (node == null)
            {
                return;
            }

            stack.Push(node);
            FindNext(node.Left);
        }

        public bool HasNex()
        {
            return stack.Count > 0;
        }

        public int Next()
        {
            TreeAgainNode current = stack.Pop();
            FindNext(current.Right);
            return current.Data;
        }
    }

    public enum TreeAgainNodeColor {Black, Red }

    public class TreeAgainNode
    {
        public int Data;
        public TreeAgainNode Left;
        public TreeAgainNode Right;
        public TreeAgainNodeColor Color;

        public TreeAgainNode(int x)
        {
            this.Data = x;
            Color = TreeAgainNodeColor.Red;
        }
    }

}
