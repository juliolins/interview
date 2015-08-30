using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class BinaryTree
    {

        public static void BuildTree()
        {
            TreeNodeInt n20 = new TreeNodeInt(20); TreeNodeInt n10 = new TreeNodeInt(10); TreeNodeInt n25 = new TreeNodeInt(25); TreeNodeInt n30 = new TreeNodeInt(30);
            TreeNodeInt n5 = new TreeNodeInt(5);

            n20.left = n10;
            n20.right = n30;
            //n10.right = n25;
            //n30.left = n5;

            int max, min;
            //Console.WriteLine("CheckBalanced = " + CheckBalanced(n20, out max, out min));
            //Console.WriteLine("UnbalancedBinary = " + UnbalancedBinary(n20));
            Console.WriteLine("CheckBalancedBook = " + CheckBalancedBook(n20, int.MinValue, int.MaxValue));
        }

        public static bool UnbalancedBinary(TreeNodeInt node)
        {
            if (node == null) 
            {
                return true;
            } else             
            {
                bool result = true;

                if (node.left != null) result = result && (node.left.data <= node.data);
                if (node.right != null) result = result && (node.right.data > node.data);

                return result && UnbalancedBinary(node.left) && UnbalancedBinary(node.right);
            }


        }

        public static bool CheckBalancedBook(TreeNodeInt node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }

            if (node.data <= min || node.data > max)
            {
                return false;
            }

            if (!CheckBalancedBook(node.left, min, node.data) || !CheckBalancedBook(node.right, node.data, max))
            {
                return false;
            }

            return true;
        }


        public static bool CheckBalanced(TreeNodeInt node, out int max, out int min)
        {
            max = node.data;
            min = node.data;
            int maxLeft = 0, maxRight = 0;
            int minLeft = 0, minRight = 0;
            bool result = true;

            if (node.left != null)
            {
                result = result && CheckBalanced(node.left, out maxLeft, out minLeft) && (maxLeft <= node.data);
                max = Math.Max(max, maxLeft);
                min = Math.Min(min, minLeft);
            }

            if (node.right != null)
            {
                result = result && CheckBalanced(node.right, out maxRight, out minRight) && (minRight > node.data);
                max = Math.Max(max, maxRight);
                min = Math.Min(min, minRight);
            }

            return result;
        }

        public class TreeNodeInt
        {
            public TreeNodeInt()
            {
            }

            public TreeNodeInt(int data)
            {
                this.data = data;
            }

            public int data;
            public TreeNodeInt left;
            public TreeNodeInt right;
        }
    }
}
