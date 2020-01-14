using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Trees
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class TreePath
    {

        public static void Test()
        {
            var one = new TreeNode(1);
            var two = new TreeNode(2);
            var three = new TreeNode(3);
            var four = new TreeNode(4);
            var five = new TreeNode(5);

            one.left = two;
            //one.right = three;
            //wo.left = four;
            //three.right = five;

            TreePath path = new TreePath();

            Console.WriteLine(path.BinaryTreePaths(one));
        }

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var result = new List<String>();
            var stack = new Stack<TreeNode>();
            TreeNode previous = null;

            if (root == null)
            {
                return result;
            }


            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Peek();

                if (isLeaf(node))
                {
                    result.Add(stackToPath(stack));
                    stack.Pop();
                    previous = node;
                    continue;
                }

                if (node.left != null && node.left != previous && (node.right != previous || node.right == null))
                {
                    stack.Push(node.left);
                    previous = node;
                    continue;
                }

                if ((node.left != null && node.left == previous) || node.left == null)
                {
                    if (node.right != null && node.right != previous)
                    {
                        stack.Push(node.right);
                        previous = node;
                        continue;
                    }
                }

                if (node.right == previous || node.right == null)
                {
                    stack.Pop();
                    previous = node;
                    continue;
                }

                previous = node;

            }

            return result;
        }

        private bool isChild(TreeNode parent, TreeNode child)
        {
            if (child == null) return false;

            return parent.left == child || parent.right == child;
        }

        private bool isLeaf(TreeNode node)
        {
            return node.left == null && node.right == null;
        }

        private String stackToPath(Stack<TreeNode> stack)
        {
            stack = new Stack<TreeNode>(stack);
            StringBuilder path = new StringBuilder();
            bool isFirst = true;

            foreach (var node in stack)
            {

                if (!isFirst) path.Append("->");
                isFirst = false;

                path.Append(node.val);
            }

            return path.ToString();
        }
    }
}
