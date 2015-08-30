using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    /// <summary>
    /// Define a SortedBinaryTree class that offers a ToList method (sorted list).
    /// </summary>
    public class SortedBinaryTree
    {
        public static void Test()
        {
            SortedBinaryTree tree = new SortedBinaryTree();

            tree.Add(4);
            tree.Add(2);
            tree.Add(6);
            tree.Add(1);
            tree.Add(0);
            tree.Add(3);
            tree.Add(5);
            tree.Add(7);

            tree.Print(new Navigate(tree.InOrderRecursive));
            tree.Print(new Navigate(tree.InOrderIteractive));
            tree.Print(new Navigate(tree.InOrderIteractiveNoStack));
            tree.Print(new Navigate(tree.InOrderRecursive));
        }

        public delegate void Navigate(TreeNodeInt node, List<int> list);

        private TreeNodeInt root;


        public void Print(Navigate navigate)
        {
            List<int> list = ToList(navigate);

            foreach (int data in list)
            {
                Console.Write(data + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Adds an element to the tree.
        /// </summary>
        public void Add(int x)
        {
            //empty tree
            if (root == null)
            {
                root = new TreeNodeInt(x);
                return;
            }

            bool found = false;
            TreeNodeInt current = root;

            while (!found)
            {
                if (x <= current.data)
                {
                    //found empty left spot
                    if (current.left == null)
                    {
                        current.left = new TreeNodeInt(x);
                        found = true;
                    }
                    else
                    {
                        //go left on the tree
                        current = current.left;
                    }
                }
                else
                {
                    //found empty left spot
                    if (current.right == null)
                    {
                        current.right = new TreeNodeInt(x);
                        found = true;
                    }
                    else
                    {
                        //go left on the tree
                        current = current.right;
                    }
                }
            }
        }

        /// <summary>
        /// Nativage the tree in pre-order
        /// </summary>
        public List<int> ToList(Navigate navigate)
        {
            List<int> list = new List<int>();

            navigate(root, list);

            return list;
        }

        private void InOrderRecursive(TreeNodeInt node, List<int> list)
        {
            if (node == null)
            {
                return;
            }

            //process left child
            InOrderRecursive(node.left, list);

            //process self
            list.Add(node.data);

            //process right child
            InOrderRecursive(node.right, list);
        }

        //http://leetcode.com/2010/04/binary-search-tree-in-order-traversal.html
        private void InOrderIteractive(TreeNodeInt node, List<int> list)
        {
            if (node == null)
            {
                return;
            }

            Stack<TreeNodeInt> stack = new Stack<TreeNodeInt>();

            while (stack.Count > 0 || node != null)
            {
                //while there's a left child, keep going left
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                //if there's no more left, process current node and then right side
                else
                {
                    node = stack.Pop();
                    list.Add(node.data);
                    node = node.right;
                }
            }
        }

        //http://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion-and-without-stack/
        private void InOrderIteractiveNoStack(TreeNodeInt current, List<int> list)
        {
            if (current == null)
            {
                return;
            }

            TreeNodeInt predecessor = null;

            while (current != null)
            {
                //if there's no left child, process node and move right
                if (current.left == null)
                {
                    list.Add(current.data);
                    current = current.right;
                }
                else
                {
                    //there's a left node

                    //find the inorder predecessor of current
                    predecessor = current.left;
                    while (predecessor.right != null && predecessor.right != current)
                        predecessor = predecessor.right;

                    // Make current as right child of its inorder predecessor
                    if (predecessor.right == null)
                    {
                        //we can now move to the left side of the tree because prodecessor.right hold a referent to current
                        //and at some point we'll process predecessor and the next after that is current
                        predecessor.right = current;
                        current = current.left;
                    }
                    else
                    {
                        //Revert the changes made in if part to restore the original 
                        //tree i.e., fix the right child of predecssor
                        predecessor.right = null;
                        list.Add(current.data);
                        current = current.right;

                    }
                }
            }
        }


        private void PreOrderIteractive(TreeNodeInt node)
        {

            Stack<TreeNodeInt> stack = new Stack<TreeNodeInt>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                node = stack.Pop();

                //process node


                //add right child
                if (node.right != null) stack.Push(node.right);

                //add left child
                if (node.left != null) stack.Push(node.left);
            }

        }

    }

    public class TreeNodeInt
    {
        public TreeNodeInt(int x)
        {
            this.data = x;
        }

        public int data;
        public TreeNodeInt left;
        public TreeNodeInt right;
    }
}
