using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class BinaryTreeToSortedList
    {

        public static void Test()
        {

            BinNode n20 = new BinNode(20);
            BinNode n10 = new BinNode(10);
            BinNode n30 = new BinNode(30);
            BinNode n5 = new BinNode(5);
            BinNode n15 = new BinNode(15);

            n20.one = n10;
            n20.two = n30;
            n10.one = n5;
            n10.two = n15;

            //BinNode current = GenerateList(n20);
            GetList(n20);
            BinNode current = head;

            BinNode tail = null;

            while (current != null)
            {
                Console.Write(current.data + " ");
                if (current.two == null) tail = current;
                current = current.two;
            }

            Console.WriteLine();

            current = tail;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.one;
            }
        }



        public static BinNode GenerateList(BinNode root)
        {
            Stack<BinNode> stack = new Stack<BinNode>();

            BinNode last = null;
            stack.Push(root);

            while (stack.Count > 0)
            {
                BinNode node = stack.Peek();

                //put in the stack before changing pointers
                if (node.two != null) stack.Push(node.two);
                if (node.one != null) stack.Push(node.one);

                //change pointers
                node.one = last;
                if (last != null) last.two = node;
                last = node;
            }

            return root;
        }

        private static BinNode last;
        private static BinNode head;

        public static void GetList(BinNode root)
        {
            if (root.one != null)
                GetList(root.one);

            //change pointers
            root.one = last;
            if (last != null) last.two = root;
            else head = root;
            last = root;

            if (root.two != null)
                GetList(root.two);

        }

    }

    

    public class BinNode
    {
        public BinNode(int data)
        {
            this.data = data;
        }

        public int data;
        public BinNode one;
        public BinNode two;
    }
}
